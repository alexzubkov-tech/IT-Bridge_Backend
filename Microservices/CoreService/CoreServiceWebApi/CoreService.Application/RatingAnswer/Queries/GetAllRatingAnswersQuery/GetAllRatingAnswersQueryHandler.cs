using CoreService.Application.RatingAnswers.Dtos;
using CoreService.Application.RatingAnswers.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.RatingAnswers.Queries.GetAllRatingAnswersQuery
{
    public class GetAllRatingAnswersQueryHandler : IRequestHandler<GetAllRatingAnswersQuery, IEnumerable<RatingAnswerDto>>
    {
        private readonly IRatingAnswerRepository _repository;
        private readonly ILogger<GetAllRatingAnswersQueryHandler> _logger;

        public GetAllRatingAnswersQueryHandler(
            IRatingAnswerRepository repository,
            ILogger<GetAllRatingAnswersQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<RatingAnswerDto>> Handle(GetAllRatingAnswersQuery request, CancellationToken ct)
        {
            try
            {
                var entities = await _repository.GetAllAsync();
                return entities.Select(e => e.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all rating answers.");
                throw;
            }
        }
    }
}