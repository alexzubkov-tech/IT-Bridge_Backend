using CoreService.Application.Companies.Dtos;
using CoreService.Application.Companies.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Companies.Queries.GetAllCompaniesQuery
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyDto>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken ct)
        {
            var companies = await _companyRepository.GetAllAsync(ct);
            return companies.Select(c => c.ToDto()).ToList();
        }
    }
}