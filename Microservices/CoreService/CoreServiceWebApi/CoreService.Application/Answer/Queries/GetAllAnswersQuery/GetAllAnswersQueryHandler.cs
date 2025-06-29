using CoreService.Application.Answers.Dtos;
using CoreService.Application.Answers.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.Answers.Queries.GetAllAnswersQuery
{
    public class GetAllAnswersQueryHandler : IRequestHandler<GetAllAnswersQuery, IEnumerable<AnswerDto>>
    {
        private readonly IAnswerRepository _repository;
        private readonly ILogger<GetAllAnswersQueryHandler> _logger;

        public GetAllAnswersQueryHandler(IAnswerRepository repository, ILogger<GetAllAnswersQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<AnswerDto>> Handle(GetAllAnswersQuery request, CancellationToken ct)
        {
            try
            {
                var entities = await _repository.GetAllAsync();
                return entities.Select(e => e.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all answers.");
                throw;
            }
        }
    }
}