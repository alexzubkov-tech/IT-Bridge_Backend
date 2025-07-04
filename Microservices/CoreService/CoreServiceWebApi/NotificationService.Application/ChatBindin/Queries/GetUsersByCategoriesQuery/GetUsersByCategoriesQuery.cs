using MediatR;

namespace NotificationBotApp.Application.Queries;

public class GetUsersByCategoriesQuery : IRequest<List<long>>
{
    public List<int> CategoryIds { get; }

    public GetUsersByCategoriesQuery(List<int> categoryIds)
    {
        CategoryIds = categoryIds;
    }
}