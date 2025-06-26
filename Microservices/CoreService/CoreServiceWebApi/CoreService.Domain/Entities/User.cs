using System.Xml.Linq;

namespace CoreService.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Guid UserProfileId { get; set; } // ну типо связь 1 -> 1
        public UserProfile UserProfile { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // для EF core, чтобы создались миграции
        public User() { }

        public User(string userName, string passwordHash, Guid userProfileId)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            PasswordHash = passwordHash;
            UserProfileId = userProfileId;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
    }
}
