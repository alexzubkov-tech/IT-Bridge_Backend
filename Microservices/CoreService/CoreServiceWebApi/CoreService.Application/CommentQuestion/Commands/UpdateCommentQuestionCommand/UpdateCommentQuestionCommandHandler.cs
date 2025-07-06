using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.CommentQuestions.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.CommentQuestions.Commands.UpdateCommentQuestionCommand
{
    public class UpdateCommentQuestionCommandHandler : IRequestHandler<UpdateCommentQuestionCommand, CommentQuestionDto>
    {
        private readonly ICommentQuestionRepository _repo;
        private readonly ILogger<UpdateCommentQuestionCommandHandler> _logger;

        public UpdateCommentQuestionCommandHandler(ICommentQuestionRepository repo, ILogger<UpdateCommentQuestionCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<CommentQuestionDto> Handle(UpdateCommentQuestionCommand request, CancellationToken ct)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(request.Id);
                if (existing == null)
                    throw new KeyNotFoundException("Comment not found");

                existing.UpdateEntityFromDto(request.Dto);
                await _repo.UpdateAsync(existing);

                return existing.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating comment.");
                throw;
            }
        }
    }
}