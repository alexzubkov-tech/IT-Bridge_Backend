using BuildingBlocks.EventBus.Abstractions;

namespace BuildingBlocks.Events
{
        public class QuestionCreatedNotificationEvent: IEvent
        {
        public QuestionCreatedNotificationEvent(string title, List<string> specializationNames)
        {
            Title = title;
            SpecializationNames = specializationNames;
        }

        public string Title { get; set; } = string.Empty;
            public List<string> SpecializationNames { get; set; } = new(); 
        }

}
