using System.Reflection.Metadata;
using CoreService.Application.Common.Interfaces;
using CoreService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers(); // <-- Важно!

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "IT-Bridge API",
        Version = "v1",
        Description = "API для менторства"
    });
});

// 🔹 Подключение к PostgreSQL
builder.Services.AddDbContext<CoreServiceDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString(nameof(CoreServiceDbContext))));

// 🔹 Регистрация интерфейса контекста (раскомментируй при необходимости)
builder.Services.AddScoped<ICoreServiceDbContext, CoreServiceDbContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ICoreServiceDbContext).Assembly));

var app = builder.Build();

// 🔹 Swagger UI
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

app.MapControllers(); 

app.Run();
