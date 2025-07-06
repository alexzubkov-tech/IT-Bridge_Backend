using CoreService.Application.UserProfile.Commands.GenerateTelegramLinkCommand;
using CoreService.Application.UserProfiles.Commands.CreateUserProfileCommand;
using CoreService.Application.UserProfiles.Commands.DeleteUserProfileCommand;
using CoreService.Application.UserProfiles.Commands.UpdateUserProfileCommand;
using CoreService.Application.UserProfiles.Dtos;
using CoreService.Application.UserProfiles.Queries.GetAllUserProfilesQuery;
using CoreService.Application.UserProfiles.Queries.GetUserProfileByIdQuery;
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
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var profile = await _mediator.Send(new GetUserProfileByIdQuery(id));
                return Ok(profile);
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var profiles = await _mediator.Send(new GetAllUserProfilesQuery());
                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteUserProfileCommand(id));
                if (!result) return NotFound("User profile not found");
                return NoContent(); // 204 - успешное удаление без содержимого
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

        [HttpGet("{id}/telegram-link")]
        public async Task<IActionResult> GetTelegramLink(int id)
        {
            var command = new GenerateTelegramLinkCommand { UserProfileId = id };
            var link = await _mediator.Send(command);
            return Ok(new { TelegramLink = link });
        }

    }
}