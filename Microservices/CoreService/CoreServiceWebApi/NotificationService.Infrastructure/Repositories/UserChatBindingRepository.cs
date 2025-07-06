using Microsoft.EntityFrameworkCore;
using NotificationBotApp.Domain.Entities;
using NotificationService.Application.Common.Interfaces;
using NotificationService.Application.Interfaces.Repositories;
using System;

namespace NotificationBotApp.Infrastructure.Repositories;

public class UserChatBindingRepository : IUserChatBindingRepository
{
    private readonly INotificationServiceDbContext _context;

    public UserChatBindingRepository(INotificationServiceDbContext context) => _context = context;

    public async Task AddAsync(UserChatBinding binding)
    {
        await _context.UserChatBindings.AddAsync(binding);
        await _context.SaveChangesAsync();
    }

    public async Task<UserChatBinding?> GetByUserProfileId(int userProfileId)
    {
        return await _context.UserChatBindings
            .FirstOrDefaultAsync(b => b.UserProfileId == userProfileId);
    }

    public async Task<bool> ExistsByUserProfileId(int userProfileId, CancellationToken ct)
    {
        return await _context.UserChatBindings
            .AnyAsync(b => b.UserProfileId == userProfileId, ct);
    }

    public async Task<List<long>> GetChatIdsByCategoryIds(List<int> categoryIds, CancellationToken ct)
    {
        return await _context.UserChatBindings
            .Where(b => categoryIds.Contains(b.CategoryId))
            .Select(b => b.ChatId)
            .Distinct()
            .ToListAsync(ct);
    }
}