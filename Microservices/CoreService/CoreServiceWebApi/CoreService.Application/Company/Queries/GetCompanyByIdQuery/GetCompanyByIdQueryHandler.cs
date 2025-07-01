using CoreService.Application.Companies.Dtos;
using CoreService.Application.Companies.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Companies.Queries.GetCompanyByIdQuery
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDetailsDto>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyByIdQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDetailsDto> Handle(GetCompanyByIdQuery request, CancellationToken ct)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id, ct);
            if (company == null)
                throw new KeyNotFoundException("Company not found");
            return company.ToDetailsDto();
        }
    }
}