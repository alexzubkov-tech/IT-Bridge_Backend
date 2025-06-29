using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.RatingQuestions.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.RatingQuestions.Commands.UpdateRatingQuestionCommand
{
    public class UpdateRatingQuestionCommandHandler : IRequestHandler<UpdateRatingQuestionCommand, RatingQuestionDto>
    {
        private readonly IRatingQuestionRepository _repo;
        private readonly ILogger<UpdateRatingQuestionCommandHandler> _logger;

        public UpdateRatingQuestionCommandHandler(IRatingQuestionRepository repo, ILogger<UpdateRatingQuestionCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<RatingQuestionDto> Handle(UpdateRatingQuestionCommand request, CancellationToken ct)
        {
            try
            {
                var existing = await _repo.GetByIdAsync(request.Id);
                if (existing == null)
                    throw new KeyNotFoundException("Rating not found");

                existing.UpdateEntityFromDto(request.Dto);
                await _repo.UpdateAsync(existing);

                return existing.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating rating.");
                throw;
            }
        }
    }
}