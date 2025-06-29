using CoreService.Application.Companies.Dtos;
using MediatR;

namespace CoreService.Application.Companies.Commands.CreateCompanyCommand
{
    public record CreateCompanyCommand(CreateCompanyDto Dto) : IRequest<CompanyDto>;
}