using CoreService.Application.Companies.Dtos;
using CoreService.Application.Companies.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Companies.Commands.UpdateCompanyCommand
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, CompanyDto>
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDto> Handle(UpdateCompanyCommand request, CancellationToken ct)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id, ct);
            if (company == null)
                throw new KeyNotFoundException("Company not found");

            company.UpdateEntityFromDto(request.Dto);
            await _companyRepository.UpdateAsync(company, ct);

            return company.ToDto();
        }
    }
}