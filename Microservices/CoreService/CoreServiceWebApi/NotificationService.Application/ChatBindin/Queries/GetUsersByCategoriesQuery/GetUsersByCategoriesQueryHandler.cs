using MediatR;
using NotificationService.Application.Interfaces.Repositories;

namespace NotificationBotApp.Application.Queries;

public class GetUsersByCategoriesQueryHandler
    : IRequestHandler<GetUsersByCategoriesQuery, List<long>>
{
    private readonly IUserChatBindingRepository _repository;

    public GetUsersByCategoriesQueryHandler(IUserChatBindingRepository repository)
        => _repository = repository;

    public async Task<List<long>> Handle(GetUsersByCategoriesQuery request, CancellationToken ct)
    {
        return await _repository.GetChatIdsByCategoryIds(request.CategoryIds, ct);
    }
}