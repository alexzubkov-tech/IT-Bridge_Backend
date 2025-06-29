using CoreService.Application.Account.Dtos;
using MediatR;

namespace CoreService.Application.Account.Queries.GetUserFullInfoQuery
{
    public record GetUserFullInfoQuery(string UserId) : IRequest<UserFullInfoDto>;
}
