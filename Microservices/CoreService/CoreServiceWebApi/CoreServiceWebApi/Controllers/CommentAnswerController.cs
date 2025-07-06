using CoreService.Application.CommentAnswers.Commands.CreateCommentAnswerCommand;
using CoreService.Application.CommentAnswers.Commands.DeleteCommentAnswerCommand;
using CoreService.Application.CommentAnswers.Commands.UpdateCommentAnswerCommand;
using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.CommentAnswers.Queries.GetAllCommentAnswersQuery;
using CoreService.Application.CommentAnswers.Queries.GetCommentAnswerByIdQuery;
using CoreService.Application.CommentAnswers.Queries.GetCommentAnswersToAnswerQuery;
using CoreService.Application.CommentQuestions.Queries.GetQuestionCommentQuestionsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceWebApi.Controllers
{
    [Route("api/comment-answer")]
    [ApiController]
    public class CommentAnswerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentAnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentAnswerDto dto)
        {
            try
            {
                var result = await _mediator.Send(new CreateCommentAnswerCommand(dto));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCommentAnswerDto dto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCommentAnswerCommand(id, dto));
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
                var result = await _mediator.Send(new GetCommentAnswerByIdQuery(id));
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
                var result = await _mediator.Send(new GetAllCommentAnswersQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("answer/{answerId}")]
        public async Task<IActionResult> GetCommentAnswer(int answerId)
        {
            try
            {
                var result = await _mediator.Send(new GetCommentAnswersToAnswerQuery(answerId));
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
                var result = await _mediator.Send(new DeleteCommentAnswerCommand(id));
                return result ? NoContent() : NotFound("CommentAnswer not found");
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