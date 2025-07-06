using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.RatingQuestions.Commands.DeleteRatingQuestionCommand
{
    public class DeleteRatingQuestionCommandHandler : IRequestHandler<DeleteRatingQuestionCommand, bool>
    {
        private readonly IRatingQuestionRepository _repo;
        private readonly ILogger<DeleteRatingQuestionCommandHandler> _logger;

        public DeleteRatingQuestionCommandHandler(IRatingQuestionRepository repo, ILogger<DeleteRatingQuestionCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteRatingQuestionCommand request, CancellationToken ct)
        {
            try
            {
                return await _repo.DeleteAsync(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting rating.");
                throw;
            }
        }
    }
}