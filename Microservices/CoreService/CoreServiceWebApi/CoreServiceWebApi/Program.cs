using Application.Account.Commands;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBusRabbitMQ;
using CoreService.Application.Behaviours;
using CoreService.Application.Common.Interfaces;
using CoreService.Application.Exceptions;
using CoreService.Application.UserProfiles.Commands.UpdateUserProfileCommand;
using CoreService.Application.UserProfiles.Validators;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using CoreService.Infrastructure;
using CoreService.Infrastructure.Repositories;
using CoreService.Infrastructure.Seeders;
using CoreService.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// 🔹 Регистрация RabbitMQ
builder.Services.RegisterRabbit(configuration);

// 🔹 ВАЖНО: Регистрируем сам IEventBus
builder.Services.AddSingleton<IEventBus, RabbitMQBus>();

// 🔹 Регистрируем паблишер событий
builder.Services.AddSingleton<IEventBusPublisher, RabbitMQBusPublisher>(provider =>
{
    var eventBus = (RabbitMQBus)provider.GetRequiredService<IEventBus>();
    return eventBus.CreatePublisher();
});

// Добавляем контроллеры
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// EF Core и регистрация контекста
builder.Services.AddDbContext<CoreServiceDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

// Регистрация ICoreServiceDbContext
builder.Services.AddScoped<ICoreServiceDbContext, CoreServiceDbContext>();

// Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 12;
}).AddEntityFrameworkStores<CoreServiceDbContext>();

// Аутентификация
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        )
    };
});

// Другие сервисы
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<ICommentQuestionRepository, CommentQuestionRepository>();
builder.Services.AddScoped<IRatingQuestionRepository, RatingQuestionRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<ICommentAnswerRepository, CommentAnswerRepository>();
builder.Services.AddScoped<IRatingAnswerRepository, RatingAnswerRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();


// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(UpdateUserProfileCommandHandler).Assembly));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddValidatorsFromAssembly(typeof(UpdateUserProfileValidator).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "IT-Bridge API v1");
        options.RoutePrefix = string.Empty;
        options.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(builder =>
{
    builder.Run(async context =>
    {
        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionFeature is not null)
        {
            var exception = exceptionFeature.Error;

            if (exception is ValidationAppException valEx)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

                await context.Response.WriteAsJsonAsync(new
                {
                    title = "One or more validation errors occurred.",
                    errors = valEx.Errors
                });

                return;
            }

            // Можно добавить другие типы исключений

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                title = "An unexpected error occurred.",
                detail = exception.Message
            });
        }
    });
});

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var dbContext = serviceProvider.GetRequiredService<CoreServiceDbContext>();
        await dbContext.Database.MigrateAsync();
        await DataSeeder.SeedAsync(serviceProvider);
    }
    catch (Exception ex)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ошибка при миграции и сидинге БД.");
    }
}

app.Run();