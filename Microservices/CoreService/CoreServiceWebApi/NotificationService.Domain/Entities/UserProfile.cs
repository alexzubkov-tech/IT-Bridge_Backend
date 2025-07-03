using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Entities
{
    public class UserProfile
    {

        public string UserId { get; set; }
        public string TelegramId { get; set; }
        public List<string> Categories { get; set; }

        public UserProfile(string userId, string telegramId, List<string> categories)
        {
            UserId = userId;
            TelegramId = telegramId;
            Categories = categories;
        }
    }
}
