using CoreService.Application.CommentQuestions.Commands.CreateCommentQuestionCommand;
using CoreService.Application.CommentQuestions.Commands.DeleteCommentQuestionCommand;
using CoreService.Application.CommentQuestions.Commands.UpdateCommentQuestionCommand;
using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.CommentQuestions.Queries.GetAllCommentQuestionsQuery;
using CoreService.Application.CommentQuestions.Queries.GetCommentQuestionByIdQuery;
using CoreService.Application.CommentQuestions.Queries.GetQuestionCommentQuestionsQuery;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceWebApi.Controllers
{
    [Route("api/comment-question")]
    [ApiController]
    public class CommentQuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentQuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentQuestionDto dto)
        {
            try
            {
                var result = await _mediator.Send(new CreateCommentQuestionCommand(dto));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCommentQuestionDto dto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCommentQuestionCommand(id, dto));
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
                var result = await _mediator.Send(new GetCommentQuestionByIdQuery(id));
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
                var result = await _mediator.Send(new GetAllCommentQuestionsQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("question/{questionId}")]
        public async Task<IActionResult> GetCommentQuestion(int questionId)
        {
            try
            {
                var result = await _mediator.Send(new GetCommentQuestionsToQuestionQuery(questionId));
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
                var result = await _mediator.Send(new DeleteCommentQuestionCommand(id));
                if (!result) return NotFound("Comment not found");
                return NoContent();
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