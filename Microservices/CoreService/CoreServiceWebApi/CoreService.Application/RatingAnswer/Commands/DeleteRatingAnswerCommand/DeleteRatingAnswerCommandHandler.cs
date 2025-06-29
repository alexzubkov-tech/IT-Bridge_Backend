using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.RatingAnswers.Commands.DeleteRatingAnswerCommand
{
    public class DeleteRatingAnswerCommandHandler : IRequestHandler<DeleteRatingAnswerCommand, bool>
    {
        private readonly IRatingAnswerRepository _repository;
        private readonly ILogger<DeleteRatingAnswerCommandHandler> _logger;

        public DeleteRatingAnswerCommandHandler(
            IRatingAnswerRepository repository,
            ILogger<DeleteRatingAnswerCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteRatingAnswerCommand request, CancellationToken ct)
        {
            try
            {
                return await _repository.DeleteAsync(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting rating answer.");
                throw;
            }
        }
    }
}