using Application.Account.Commands;
using CoreService.Application.Account.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(LoginDto dto)
        //{
        //    var user = await _mediator.Send(new LoginUserQuery(dto));
        //    return Ok(user);
        //}

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = await _mediator.Send(new RegisterUserCommand(dto));
            return Ok(user);
        }
    }
}