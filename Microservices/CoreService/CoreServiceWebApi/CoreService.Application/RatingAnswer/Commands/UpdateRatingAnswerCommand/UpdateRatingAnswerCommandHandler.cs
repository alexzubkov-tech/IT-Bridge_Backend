using CoreService.Application.RatingAnswers.Dtos;
using CoreService.Application.RatingAnswers.Mapper;
using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.RatingAnswers.Commands.UpdateRatingAnswerCommand
{
    public class UpdateRatingAnswerCommandHandler : IRequestHandler<UpdateRatingAnswerCommand, RatingAnswerDto>
    {
        private readonly IRatingAnswerRepository _repository;
        private readonly ILogger<UpdateRatingAnswerCommandHandler> _logger;

        public UpdateRatingAnswerCommandHandler(
            IRatingAnswerRepository repository,
            ILogger<UpdateRatingAnswerCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<RatingAnswerDto> Handle(UpdateRatingAnswerCommand request, CancellationToken ct)
        {
            try
            {
                var existing = await _repository.GetByIdAsync(request.Id);
                if (existing == null)
                    throw new KeyNotFoundException("RatingAnswer not found");

                existing.UpdateEntityFromDto(request.Dto);
                await _repository.UpdateAsync(existing);

                return existing.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating rating answer.");
                throw;
            }
        }
    }
}