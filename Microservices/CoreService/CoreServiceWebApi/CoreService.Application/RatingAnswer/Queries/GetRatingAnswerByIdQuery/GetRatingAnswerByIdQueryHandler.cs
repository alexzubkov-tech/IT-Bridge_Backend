using CoreService.Application.RatingAnswers.Dtos;
using CoreService.Application.RatingAnswers.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.RatingAnswers.Queries.GetRatingAnswerByIdQuery
{
    public class GetRatingAnswerByIdQueryHandler : IRequestHandler<GetRatingAnswerByIdQuery, RatingAnswerDto>
    {
        private readonly IRatingAnswerRepository _repository;
        private readonly ILogger<GetRatingAnswerByIdQueryHandler> _logger;

        public GetRatingAnswerByIdQueryHandler(
            IRatingAnswerRepository repository,
            ILogger<GetRatingAnswerByIdQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<RatingAnswerDto> Handle(GetRatingAnswerByIdQuery request, CancellationToken ct)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity == null)
                    throw new KeyNotFoundException("RatingAnswer not found");

                return entity.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting rating answer by ID.");
                throw;
            }
        }
    }
}