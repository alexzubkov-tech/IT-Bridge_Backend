using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Entities
{
    public class UserProfile
    {
        public UserProfile(int userProfileId, long? chatId, string categoryName)
        {
            UserProfileId = userProfileId;
            ChatId = chatId;
            CategoryName = categoryName;
        }

        public int UserProfileId { get; set; } 
        public long? ChatId { get; set; } 
        public string CategoryName { get; set; } = string.Empty;
 

    }
}
