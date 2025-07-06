using CoreService.Application.Companies.Dtos;
using MediatR;

namespace CoreService.Application.Companies.Queries.GetCompanyByIdQuery
{
    public record GetCompanyByIdQuery(int Id) : IRequest<CompanyDetailsDto>;
}