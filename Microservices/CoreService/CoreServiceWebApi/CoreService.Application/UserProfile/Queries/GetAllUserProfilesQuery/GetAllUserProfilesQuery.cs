using CoreService.Application.UserProfiles.Dtos;
using MediatR;

namespace CoreService.Application.UserProfiles.Queries.GetAllUserProfilesQuery
{
    public record GetAllUserProfilesQuery() : IRequest<List<UserProfileDto>>;
}
