using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.CommentAnswers.Commands.DeleteCommentAnswerCommand
{
    public class DeleteCommentAnswerCommandHandler : IRequestHandler<DeleteCommentAnswerCommand, bool>
    {
        private readonly ICommentAnswerRepository _repository;
        private readonly ILogger<DeleteCommentAnswerCommandHandler> _logger;

        public DeleteCommentAnswerCommandHandler(
            ICommentAnswerRepository repository,
            ILogger<DeleteCommentAnswerCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteCommentAnswerCommand request, CancellationToken ct)
        {
            try
            {
                return await _repository.DeleteAsync(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting comment answer.");
                throw;
            }
        }
    }
}