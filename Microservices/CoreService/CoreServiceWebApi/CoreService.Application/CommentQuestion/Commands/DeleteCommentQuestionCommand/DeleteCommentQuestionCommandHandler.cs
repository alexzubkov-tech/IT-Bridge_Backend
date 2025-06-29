using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.CommentQuestions.Commands.DeleteCommentQuestionCommand
{
    public class DeleteCommentQuestionCommandHandler : IRequestHandler<DeleteCommentQuestionCommand, bool>
    {
        private readonly ICommentQuestionRepository _repo;
        private readonly ILogger<DeleteCommentQuestionCommandHandler> _logger;

        public DeleteCommentQuestionCommandHandler(ICommentQuestionRepository repo, ILogger<DeleteCommentQuestionCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteCommentQuestionCommand request, CancellationToken ct)
        {
            try
            {
                return await _repo.DeleteAsync(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting comment.");
                throw;
            }
        }
    }
}