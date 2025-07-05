using CoreService.Application.Questions.Commands.CreateQuestionCommand;
using CoreService.Application.Questions.Commands.DeleteQuestionCommand;
using CoreService.Application.Questions.Commands.UpdateQuestionCommand;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.Questions.Queries.GetAllQuestionsQuery;
using CoreService.Application.Questions.Queries.GetQuestionByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceWebApi.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuestionDto dto, [FromQuery] int userProfileId)
        {
            var result = await _mediator.Send(new CreateQuestionCommand(dto, userProfileId));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateQuestionDto dto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateQuestionCommand(id, dto));
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
                var result = await _mediator.Send(new GetQuestionByIdQuery(id));
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

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] string? title = null)
        {
            try
            {
                var result = await _mediator.Send(new GetAllQuestionsQuery(title));
                return Ok(result);
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
                var result = await _mediator.Send(new DeleteQuestionCommand(id));
                return result ? NoContent() : NotFound("Question not found");
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