namespace NotificationService.Application.Common.Interfaces
{
    public interface IQuestionService
    {
        Task OnQuestionCreatedAsync(List<int> categoryIds, CancellationToken ct);
    }
}
