using CoreService.Application.UserProfiles.Dtos;
using MediatR;

namespace CoreService.Application.UserProfiles.Queries.GetUserProfileByIdQuery
{
    public record GetUserProfileByIdQuery(int Id) : IRequest<UserProfileDetaisDto>;
}
