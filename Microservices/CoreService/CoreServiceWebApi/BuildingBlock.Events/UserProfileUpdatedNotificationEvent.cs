
using BuildingBlocks.EventBus.Abstractions;

namespace BuildingBlock.Events
{
    public class UserProfileUpdatedNotificationEvent : IEvent
    {
        public UserProfileUpdatedNotificationEvent(int userProfileId, string categoryName)
        {
            UserProfileId = userProfileId;
            CategoryName = categoryName;
        }


        public int UserProfileId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
