using CoreService.Application.Companies.Dtos;
using MediatR;
using System.Collections.Generic;

namespace CoreService.Application.Companies.Queries.GetAllCompaniesQuery
{
    public record GetAllCompaniesQuery() : IRequest<List<CompanyDto>>;
}