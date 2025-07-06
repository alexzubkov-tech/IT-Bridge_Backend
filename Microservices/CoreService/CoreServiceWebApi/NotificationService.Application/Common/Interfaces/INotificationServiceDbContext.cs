using Microsoft.EntityFrameworkCore;
using NotificationBotApp.Domain.Entities;

namespace NotificationService.Application.Common.Interfaces
{
    public interface INotificationServiceDbContext
    {
        public DbSet<UserChatBinding> UserChatBindings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
