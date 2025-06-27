using CoreService.Application.UserProfiles.Commands.UpdateUserProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateProfile(Guid userId, UpdateUserProfileCommand command)
    {
        if (userId != command.UserId)
            return BadRequest("Mismatched userId");

        await _mediator.Send(command);
        return NoContent();
    }

    //[HttpGet("{userId}")]
    //public async Task<IActionResult> GetProfile(Guid userId)
    //{
    //    var profile = await _mediator.Send(new GetUserProfileByIdQuery(userId));
    //    return Ok(profile);
    //}
}
