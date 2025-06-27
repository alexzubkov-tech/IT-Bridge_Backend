using MediatR;

public class GetUserProfileByIdQuery : IRequest<UserProfileDto>
{
    public Guid UserId { get; set; }

    public GetUserProfileByIdQuery(Guid userId)
    {
        UserId = userId;
    }
}
