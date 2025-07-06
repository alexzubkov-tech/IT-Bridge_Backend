using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.CommentAnswers.Mapper;
using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.CommentAnswers.Commands.CreateCommentAnswerCommand
{
    public class CreateCommentAnswerCommandHandler : IRequestHandler<CreateCommentAnswerCommand, CommentAnswerDto>
    {
        private readonly ICommentAnswerRepository _repository;
        private readonly ILogger<CreateCommentAnswerCommandHandler> _logger;

        public CreateCommentAnswerCommandHandler(
            ICommentAnswerRepository repository,
            ILogger<CreateCommentAnswerCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CommentAnswerDto> Handle(CreateCommentAnswerCommand request, CancellationToken ct)
        {
            try
            {
                var entity = request.Dto.ToEntity();
                await _repository.CreateAsync(entity);
                return entity.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating comment answer.");
                throw;
            }
        }
    }
}