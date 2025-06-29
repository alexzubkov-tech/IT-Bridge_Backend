using CoreService.Application.RatingAnswers.Commands.CreateRatingAnswerCommand;
using CoreService.Application.RatingAnswers.Commands.DeleteRatingAnswerCommand;
using CoreService.Application.RatingAnswers.Commands.UpdateRatingAnswerCommand;
using CoreService.Application.RatingAnswers.Dtos;
using CoreService.Application.RatingAnswers.Queries.GetAllRatingAnswersQuery;
using CoreService.Application.RatingAnswers.Queries.GetRatingAnswerByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceWebApi.Controllers
{
    [Route("api/rating-answer")]
    [ApiController]
    public class RatingAnswerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RatingAnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRatingAnswerDto dto)
        {
            try
            {
                var result = await _mediator.Send(new CreateRatingAnswerCommand(dto));
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
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRatingAnswerDto dto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateRatingAnswerCommand(id, dto));
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
                var result = await _mediator.Send(new GetRatingAnswerByIdQuery(id));
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
                var result = await _mediator.Send(new GetAllRatingAnswersQuery());
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
                var result = await _mediator.Send(new DeleteRatingAnswerCommand(id));
                return result ? NoContent() : NotFound("RatingAnswer not found");
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