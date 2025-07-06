using MediatR;

namespace CoreService.Application.Companies.Commands.DeleteCompanyCommand
{
    public record DeleteCompanyCommand(int Id) : IRequest<bool>;
}