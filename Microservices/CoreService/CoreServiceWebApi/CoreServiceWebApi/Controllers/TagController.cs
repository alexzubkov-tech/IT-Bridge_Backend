using Microsoft.AspNetCore.Mvc;
using CoreService.Application.Tags.Commands.CreateTagCommand;
using CoreService.Application.Tags.Commands.DeleteTagCommand;
using CoreService.Application.Tags.Commands.UpdateTagCommand;
using CoreService.Application.Tags.Dtos;
using CoreService.Application.Tags.Queries.GetAllTagsQuery;
using CoreService.Application.Tags.Queries.GetTagByIdQuery;
using MediatR;

namespace CoreServiceWebApi.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagDto dto)
        {
            try
            {
                var result = await _mediator.Send(new CreateTagCommand(dto));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetTagByIdQuery(id));
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllTagsQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTagDto dto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateTagCommand(id, dto));
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteTagCommand(id));
                return result ? NoContent() : NotFound("Tag not found");
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