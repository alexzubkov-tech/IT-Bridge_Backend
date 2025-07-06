﻿using BuildingBlocks.EventBus.Abstractions;

namespace BuildingBlocks.Events
{
    public class QuestionCreatedNotificationEvent : IEvent
    {

        public int QuestionId { get; }
        public string Title { get; }
        public string Link { get; }
        public List<int> CategoryIds { get; }

        public QuestionCreatedNotificationEvent(int questionId, string title, string link, List<int> categoryIds)
        {
            QuestionId = questionId;
            Title = title;
            Link = link;
            CategoryIds = categoryIds;
        }
    }

}