using MediatR;
using CoreService.Domain.Entities;
using CoreService.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CoreService.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly ICoreServiceDbContext _context;

        public RegisterUserCommandHandler(ICoreServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Проверка: существует ли пользователь с таким Email
            if (await _context.Users.AnyAsync(u => u.Email == request.Email, cancellationToken))
                throw new Exception("User with this email already exists.");

            // Хэш пароля (можно заменить на IPasswordHasher и DI, но пока просто)
            var passwordHash = ComputeSha256Hash(request.Password);

            // Создаём UserProfile
            var userProfile = new UserProfile(request.Email);
            await _context.UserProfiles.AddAsync(userProfile, cancellationToken);

            // Создаём User
            var user = new User(request.Email, passwordHash, userProfile.Id);
            await _context.Users.AddAsync(user, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

        // надо это потом поменять, хеш
        private static string ComputeSha256Hash(string rawData)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }
    }
}
