using CoreService.Application.UserProfiles.Commands.CreateUserProfileCommand;
using CoreService.Application.UserProfiles.Commands.UpdateUserProfileCommand;
using CoreService.Application.UserProfiles.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceWebApi.Controllers
{
    [Route("api/user-profile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserProfileDto dto, [FromQuery] string userId)
        {
            try
            {
                var result = await _mediator.Send(new CreateUserProfileCommand(userId, dto));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserProfileDto dto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateUserProfileCommand(id, dto));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
