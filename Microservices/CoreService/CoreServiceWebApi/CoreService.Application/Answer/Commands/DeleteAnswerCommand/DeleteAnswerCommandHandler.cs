using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.Answers.Commands.DeleteAnswerCommand
{
    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand, bool>
    {
        private readonly IAnswerRepository _repository;
        private readonly ILogger<DeleteAnswerCommandHandler> _logger;

        public DeleteAnswerCommandHandler(IAnswerRepository repository, ILogger<DeleteAnswerCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteAnswerCommand request, CancellationToken ct)
        {
            try
            {
                return await _repository.DeleteAsync(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting answer.");
                throw;
            }
        }
    }
}