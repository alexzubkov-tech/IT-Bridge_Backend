using CoreService.Application.Answers.Commands.CreateAnswerCommand;
using CoreService.Application.Answers.Commands.DeleteAnswerCommand;
using CoreService.Application.Answers.Commands.UpdateAnswerCommand;
using CoreService.Application.Answers.Dtos;
using CoreService.Application.Answers.Queries.GetAllAnswersQuery;
using CoreService.Application.Answers.Queries.GetAnswerByIdQuery;
using CoreService.Application.Answers.Queries.GetAnswersByQuestionIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceWebApi.Controllers
{
    [Route("api/answer")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnswerDto dto)
        {
            try
            {
                var result = await _mediator.Send(new CreateAnswerCommand(dto));
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
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAnswerDto dto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateAnswerCommand(id, dto));
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetAnswerByIdQuery(id));
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
                var result = await _mediator.Send(new GetAllAnswersQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("question/{questionId}")]
        public async Task<IActionResult> GetAnswersByQuestionId(int questionId)
        {
            try
            {
                var result = await _mediator.Send(new GetAnswersByQuestionIdQuery(questionId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteAnswerCommand(id));
                return result ? NoContent() : NotFound("Answer not found");
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