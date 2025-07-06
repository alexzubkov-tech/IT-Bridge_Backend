using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.CommentAnswers.Mapper;
using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.CommentAnswers.Commands.UpdateCommentAnswerCommand
{
    public class UpdateCommentAnswerCommandHandler : IRequestHandler<UpdateCommentAnswerCommand, CommentAnswerDto>
    {
        private readonly ICommentAnswerRepository _repository;
        private readonly ILogger<UpdateCommentAnswerCommandHandler> _logger;

        public UpdateCommentAnswerCommandHandler(
            ICommentAnswerRepository repository,
            ILogger<UpdateCommentAnswerCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CommentAnswerDto> Handle(UpdateCommentAnswerCommand request, CancellationToken ct)
        {
            try
            {
                var existing = await _repository.GetByIdAsync(request.Id);
                if (existing == null)
                    throw new KeyNotFoundException("CommentAnswer not found");


                existing.UpdateEntityFromDto(request.Dto);
                await _repository.UpdateAsync(existing);

                return existing.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating comment answer.");
                throw;
            }
        }
    }
}