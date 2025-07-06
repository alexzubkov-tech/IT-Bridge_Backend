using CoreService.Application.RatingQuestions.Commands.CreateRatingQuestionCommand;
using CoreService.Application.RatingQuestions.Commands.DeleteRatingQuestionCommand;
using CoreService.Application.RatingQuestions.Commands.UpdateRatingQuestionCommand;
using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.RatingQuestions.Queries.GetAllRatingQuestionsQuery;
using CoreService.Application.RatingQuestions.Queries.GetQuestionRatingQuestionsQuery;
using CoreService.Application.RatingQuestions.Queries.GetRatingByQuestion;
using CoreService.Application.RatingQuestions.Queries.GetRatingQuestionByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceWebApi.Controllers
{
    [Route("api/rating-question")]
    [ApiController]
    public class RatingQuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RatingQuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRatingQuestionDto dto)
        {
            try
            {
                var result = await _mediator.Send(new CreateRatingQuestionCommand(dto));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRatingQuestionDto dto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateRatingQuestionCommand(id, dto));
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
                var profile = await _mediator.Send(new GetRatingQuestionByIdQuery(id));
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
                var profiles = await _mediator.Send(new GetAllRatingQuestionsQuery());
                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("rating-by-question")]
        public async Task<IActionResult> GetRatingByQuestion(CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(new GetRatingByQuestionQuery(), ct);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("question/{questionId}")]
        public async Task<IActionResult> GetRatingQuestion(int questionId)
        {
            try
            {
                var result = await _mediator.Send(new GetRatingQuestionToQuestionQuery(questionId));
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
                var result = await _mediator.Send(new DeleteRatingQuestionCommand(id));
                if (!result) return NotFound("Rating not found");
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