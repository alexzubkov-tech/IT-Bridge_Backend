using CoreService.Application.Account.Dtos;
using CoreService.Application.Common.Interfaces;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Account.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, NewUserDto>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly ICoreServiceDbContext _context;

        public LoginUserCommandHandler(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            ITokenService tokenService,
            ICoreServiceDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }

        public async Task<NewUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var loginDto = request.LoginDto;

            var user = await _userManager.FindByNameAsync(loginDto.Username);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                throw new UnauthorizedAccessException("Invalid credentials");

            var profile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.UserId == user.Id, cancellationToken);

            if (profile == null)
                throw new InvalidOperationException("User profile not found.");

            return new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user, profile.Id),
            };
        }
    }
}