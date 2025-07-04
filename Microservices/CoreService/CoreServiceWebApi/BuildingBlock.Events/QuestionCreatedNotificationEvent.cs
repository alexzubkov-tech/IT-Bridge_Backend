﻿using BuildingBlocks.EventBus.Abstractions;

namespace BuildingBlocks.Events
{
    public class QuestionCreatedNotificationEvent : IEvent
    {

        public int QuestionId { get; }
        public string Title { get; }
        public List<int> CategoryIds { get; }

        public QuestionCreatedNotificationEvent(int questionId, string title, List<int> categoryIds)
        {
            QuestionId = questionId;
            Title = title;
            CategoryIds = categoryIds;
        }
    }

}