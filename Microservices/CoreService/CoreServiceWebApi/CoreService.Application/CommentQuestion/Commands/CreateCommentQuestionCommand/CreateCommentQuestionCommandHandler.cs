using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.CommentQuestions.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.CommentQuestions.Commands.CreateCommentQuestionCommand
{
    public class CreateCommentQuestionCommandHandler : IRequestHandler<CreateCommentQuestionCommand, CommentQuestionDto>
    {
        private readonly ICommentQuestionRepository _repo;
        private readonly ILogger<CreateCommentQuestionCommandHandler> _logger;

        public CreateCommentQuestionCommandHandler(ICommentQuestionRepository repo, ILogger<CreateCommentQuestionCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<CommentQuestionDto> Handle(CreateCommentQuestionCommand request, CancellationToken ct)
        {
            try
            {
                var entity = request.Dto.ToEntity();
                await _repo.CreateAsync(entity);
                return entity.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating comment.");
                throw;
            }
        }
    }
}