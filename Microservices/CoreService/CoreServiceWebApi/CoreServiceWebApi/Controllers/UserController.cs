using CoreService.Application.Users.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }

    //[HttpPost("confirm-email")]
    //public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
    //{
    //    await _mediator.Send(command);
    //    return Ok();
    //}

    //[HttpGet("check-username")]
    //public async Task<IActionResult> CheckUsername([FromQuery] string username)
    //{
    //    var exists = await _mediator.Send(new CheckUsernameQuery(username));
    //    return Ok(new { exists });
    //}
}
