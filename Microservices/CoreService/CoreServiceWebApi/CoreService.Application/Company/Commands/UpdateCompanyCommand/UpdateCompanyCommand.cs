using CoreService.Application.Companies.Dtos;
using MediatR;

namespace CoreService.Application.Companies.Commands.UpdateCompanyCommand
{
    public record UpdateCompanyCommand(int Id, UpdateCompanyDto Dto) : IRequest<CompanyDto>;
}