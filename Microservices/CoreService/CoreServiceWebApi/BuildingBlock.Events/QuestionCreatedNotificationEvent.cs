﻿using BuildingBlocks.EventBus.Abstractions;

namespace BuildingBlocks.Events
{
    public class QuestionCreatedNotificationEvent : IEvent
    {
       
        public QuestionCreatedNotificationEvent(int questionId, string title, List<string> specializationNames)
        {
            QuestionId = questionId;
            Title = title;
            SpecializationNames = specializationNames;
        }

        public int QuestionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<string> SpecializationNames { get; set; } = new();
    }

}