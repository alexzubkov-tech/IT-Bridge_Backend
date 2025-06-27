//using Application.Categories.Commands;
//using Application.Categories.DTOs;
//using Application.Categories.Queries;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CategoriesController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public CategoriesController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
//        {
//            var result = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken);
//            return Ok(result);
//        }

//        [HttpGet("{id:guid}")]
//        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
//        {
//            var result = await _mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
//            return Ok(result);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto, CancellationToken cancellationToken)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var category = await _mediator.Send(new CreateCategoryCommand(dto), cancellationToken);
//            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
//        }

//        [HttpPut("{id:guid}")]
//        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryDto dto, CancellationToken cancellationToken)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var category = await _mediator.Send(new UpdateCategoryCommand(id, dto), cancellationToken);
//            return Ok(category);
//        }

//        [HttpDelete("{id:guid}")]
//        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
//        {
//            await _mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
//            return NoContent();
//        }
//    }
//}
