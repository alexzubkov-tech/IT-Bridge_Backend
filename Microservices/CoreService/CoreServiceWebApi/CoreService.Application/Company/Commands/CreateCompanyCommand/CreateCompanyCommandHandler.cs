using CoreService.Application.Companies.Dtos;
using CoreService.Application.Companies.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Companies.Commands.CreateCompanyCommand
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken ct)
        {
            var company = request.Dto.ToEntity();
            var id = await _companyRepository.CreateAsync(company, ct);
            company.Id = id;
            return company.ToDto();
        }
    }
}