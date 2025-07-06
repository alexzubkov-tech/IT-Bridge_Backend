using Microsoft.AspNetCore.Mvc;
using CoreService.Application.Companies.Commands.CreateCompanyCommand;
using CoreService.Application.Companies.Commands.DeleteCompanyCommand;
using CoreService.Application.Companies.Commands.UpdateCompanyCommand;
using CoreService.Application.Companies.Dtos;
using CoreService.Application.Companies.Queries.GetAllCompaniesQuery;
using CoreService.Application.Companies.Queries.GetCompanyByIdQuery;
using MediatR;

namespace CoreServiceWebApi.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyDto dto)
        {
            var result = await _mediator.Send(new CreateCompanyCommand(dto));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetCompanyByIdQuery(id));
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
                var result = await _mediator.Send(new GetAllCompaniesQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyDto dto)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCompanyCommand(id, dto));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCompanyCommand(id));
                if (!result) return NotFound("Company not found");
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