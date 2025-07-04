using Microsoft.EntityFrameworkCore;
using NotificationBotApp.Domain.Entities;
using NotificationService.Application.Common.Interfaces;


namespace NotificationService.Infrastructure
{
    public class NotificationServiceDbContext : DbContext, INotificationServiceDbContext
    {
        public NotificationServiceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }


        public DbSet<UserChatBinding> UserChatBindings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
