using CoreService.Application.Answers.Dtos;
using CoreService.Application.Answers.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.Answers.Queries.GetAnswerByIdQuery
{
    public class GetAnswerByIdQueryHandler : IRequestHandler<GetAnswerByIdQuery, AnswerDto>
    {
        private readonly IAnswerRepository _repository;
        private readonly ILogger<GetAnswerByIdQueryHandler> _logger;

        public GetAnswerByIdQueryHandler(IAnswerRepository repository, ILogger<GetAnswerByIdQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<AnswerDto> Handle(GetAnswerByIdQuery request, CancellationToken ct)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);
                if (entity == null)
                    throw new KeyNotFoundException("Answer not found");

                return entity.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting answer by ID.");
                throw;
            }
        }
    }
}