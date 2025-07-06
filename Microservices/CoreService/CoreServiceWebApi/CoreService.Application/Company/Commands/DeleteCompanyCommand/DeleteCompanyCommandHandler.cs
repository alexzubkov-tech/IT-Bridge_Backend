using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Companies.Commands.DeleteCompanyCommand
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken ct)
        {
            var result = await _companyRepository.DeleteAsync(request.Id, ct);
            if (!result) throw new KeyNotFoundException("Company not found");
            return result;
        }
    }
}