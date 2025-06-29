using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.CommentAnswers.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.CommentAnswers.Queries.GetCommentAnswerByIdQuery
{
    public class GetCommentAnswerByIdQueryHandler : IRequestHandler<GetCommentAnswerByIdQuery, CommentAnswerDto>
    {
        private readonly ICommentAnswerRepository _repository;
        private readonly ILogger<GetCommentAnswerByIdQueryHandler> _logger;

        public GetCommentAnswerByIdQueryHandler(
            ICommentAnswerRepository repository,
            ILogger<GetCommentAnswerByIdQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CommentAnswerDto> Handle(GetCommentAnswerByIdQuery request, CancellationToken ct)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity == null)
                    throw new KeyNotFoundException("CommentAnswer not found");

                return entity.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting comment answer by ID.");
                throw;
            }
        }
    }
}