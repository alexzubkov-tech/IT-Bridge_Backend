using CoreService.Application.Account.Dtos;
using CoreService.Application.Common.Interfaces;
using CoreService.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Application.Account.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, NewUserDto>
    {
        private readonly ICoreServiceDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterUserCommandHandler(
            ICoreServiceDbContext context,
            UserManager<User> userManager,
            ITokenService tokenService)
        {
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<NewUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = new User
            {
                UserName = request.RegisterDto.Username.ToLower(),
                Email = request.RegisterDto.Email
            };

            var createdUser = await _userManager.CreateAsync(appUser, request.RegisterDto.Password);

            if (!createdUser.Succeeded)
            {
                throw new Exception(string.Join("; ", createdUser.Errors.Select(e => e.Description)));
            }

            var userProfile = new UserProfile
            {
                UserId = appUser.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsExpert = false,
                FIO = appUser.UserName,
                Bio = string.Empty,
                GithubUrl = string.Empty,
                LinkedinUrl = string.Empty,
                TelegramId = string.Empty,
                ResumeLink = string.Empty
            };

            await _context.UserProfiles.AddAsync(userProfile, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new NewUserDto
            {
                UserName = appUser.UserName,
                Email = appUser.Email,
                Token = await _tokenService.CreateToken(appUser),
            };
        }
    }
}