using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.RatingQuestions.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.RatingQuestions.Commands.CreateRatingQuestionCommand
{
    public class CreateRatingQuestionCommandHandler : IRequestHandler<CreateRatingQuestionCommand, RatingQuestionDto>
    {
        private readonly IRatingQuestionRepository _repo;
        private readonly ILogger<CreateRatingQuestionCommandHandler> _logger;

        public CreateRatingQuestionCommandHandler(IRatingQuestionRepository repo, ILogger<CreateRatingQuestionCommandHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<RatingQuestionDto> Handle(CreateRatingQuestionCommand request, CancellationToken ct)
        {
            try
            {
                var entity = request.Dto.ToEntity();
                await _repo.CreateAsync(entity);
                return entity.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating rating.");
                throw;
            }
        }
    }
}