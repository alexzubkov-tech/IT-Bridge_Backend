using CoreService.Application.Account.Dtos;
using CoreService.Application.Common.Interfaces;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
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
        private readonly IUserProfileRepository _userProfileRepository;

        public RegisterUserCommandHandler(
            ICoreServiceDbContext context,
            UserManager<User> userManager,
            ITokenService tokenService,
            IUserProfileRepository userProfileRepository)
        {
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<NewUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = new User
            {
                UserName = request.RegisterDto.Username,
                Email = request.RegisterDto.Email
            };

            var createdUser = await _userManager.CreateAsync(appUser, request.RegisterDto.Password);

            if (!createdUser.Succeeded)
            {
                throw new Exception(string.Join("; ", createdUser.Errors.Select(e => e.Description)));
            }

            var profile = new UserProfile
            {
                UserId = appUser.Id,
                FIO = appUser.UserName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _userProfileRepository.CreateAsync(profile);
            await _context.SaveChangesAsync(cancellationToken);

            int userProfileId = profile.Id;

            return new NewUserDto
            {
                UserName = appUser.UserName,
                Email = appUser.Email,
                Token = await _tokenService.CreateToken(appUser, userProfileId),
            };
        }
    }
}