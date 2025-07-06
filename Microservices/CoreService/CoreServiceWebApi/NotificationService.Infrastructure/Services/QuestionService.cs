using MediatR;
using NotificationBotApp.Application.Queries;
using NotificationService.Application.Common.Interfaces;

public class QuestionService : IQuestionService
{
    private readonly IMediator _mediator;
    private readonly NotifyService _notifyService;

    public QuestionService(IMediator mediator, NotifyService notifyService)
    {
        _mediator = mediator;
        _notifyService = notifyService;
    }

    public async Task OnQuestionCreatedAsync(List<int> categoryIds, CancellationToken ct)
    {
        var chatIds = await _mediator.Send(new GetUsersByCategoriesQuery(categoryIds), ct);

        if (chatIds.Count > 0)
        {
            await _notifyService.NotifyChatsAsync(chatIds, "🔔 Создан новый вопрос!", ct);
        }
    }
}