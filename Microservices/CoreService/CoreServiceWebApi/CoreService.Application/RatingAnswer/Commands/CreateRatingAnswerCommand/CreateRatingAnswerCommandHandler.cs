using CoreService.Application.RatingAnswers.Dtos;
using CoreService.Application.RatingAnswers.Mapper;
using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.RatingAnswers.Commands.CreateRatingAnswerCommand
{
    public class CreateRatingAnswerCommandHandler : IRequestHandler<CreateRatingAnswerCommand, RatingAnswerDto>
    {
        private readonly IRatingAnswerRepository _repository;
        private readonly ILogger<CreateRatingAnswerCommandHandler> _logger;

        public CreateRatingAnswerCommandHandler(
            IRatingAnswerRepository repository,
            ILogger<CreateRatingAnswerCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<RatingAnswerDto> Handle(CreateRatingAnswerCommand request, CancellationToken ct)
        {
            try
            {
                var entity = request.Dto.ToEntity();
                await _repository.CreateAsync(entity);
                return entity.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating rating answer.");
                throw;
            }
        }
    }

}