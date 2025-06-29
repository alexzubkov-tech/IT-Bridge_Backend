using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.CommentAnswers.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.CommentAnswers.Queries.GetAllCommentAnswersQuery
{
    public class GetAllCommentAnswersQueryHandler : IRequestHandler<GetAllCommentAnswersQuery, IEnumerable<CommentAnswerDto>>
    {
        private readonly ICommentAnswerRepository _repository;
        private readonly ILogger<GetAllCommentAnswersQueryHandler> _logger;

        public GetAllCommentAnswersQueryHandler(
            ICommentAnswerRepository repository,
            ILogger<GetAllCommentAnswersQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<CommentAnswerDto>> Handle(GetAllCommentAnswersQuery request, CancellationToken ct)
        {
            try
            {
                var entities = await _repository.GetAllAsync();
                return entities.Select(e => e.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all comment answers.");
                throw;
            }
        }
    }
}