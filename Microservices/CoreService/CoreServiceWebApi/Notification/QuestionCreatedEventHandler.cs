// NotificationBotApp.Application.EventHandlers.QuestionCreatedEventHandler.cs

using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.Events;
using MediatR;
using NotificationBotApp.Application.Queries;
using NotificationBotApp.Infrastructure.Bot;

namespace NotificationBotApp.Application.EventHandlers
{
    public class QuestionCreatedEventHandler : IEventHandler<QuestionCreatedNotificationEvent>
    {
        private readonly INotifyService _notifyService;
        private readonly IMediator _mediator;

        public QuestionCreatedEventHandler(INotifyService notifyService, IMediator mediator)
        {
            _notifyService = notifyService;
            _mediator = mediator;
        }

        public async Task Handle(QuestionCreatedNotificationEvent @event)
        {
            if (@event.CategoryIds == null || !@event.CategoryIds.Any())
            {
                Console.WriteLine("Нет категорий для рассылки.");
                return;
            }

            string message =
                "<b>🎉 Новый вопрос!</b>\n" +
                $"👉 <i>Заголовок:</i> '{@event.Title}'\n\n" +
                $"🤔 <i>Хотите помочь?</i>\n" +
                $"🔗 Ссылка на вопрос 👇:\n" +
                $"<b><a href=\"{@event.Link}\">{@event.Link}</a></b>\n\n" +
                $"🌟 <b>Станьте героем дня!</b>";

            var chatIds = await _mediator.Send(new GetUsersByCategoriesQuery(@event.CategoryIds));

            if (!chatIds.Any())
            {
                Console.WriteLine("Нет пользователей для рассылки.");
                return;
            }

            await _notifyService.NotifyChatsAsync(chatIds, message);
        }
    }
}