using CoreService.Application.Answers.Dtos;
using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.Answers.Queries.GetAnswersByQuestionIdQuery
{
    public class GetAnswersByQuestionIdQueryHandler
        : IRequestHandler<GetAnswersByQuestionIdQuery, IEnumerable<AnswerWithUserInfoDto>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly ILogger<GetAnswersByQuestionIdQueryHandler> _logger;

        public GetAnswersByQuestionIdQueryHandler(
            IAnswerRepository answerRepository,
            ILogger<GetAnswersByQuestionIdQueryHandler> logger)
        {
            _answerRepository = answerRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<AnswerWithUserInfoDto>> Handle(
            GetAnswersByQuestionIdQuery request,
            CancellationToken ct)
        {
            try
            {
                var answers = await _answerRepository.GetByQuestionIdAsync(request.QuestionId);

                return answers.Select(a => new AnswerWithUserInfoDto
                {
                    Id = a.Id,
                    Content = a.Content,
                    CreatedAt = a.CreatedAt,
                    AuthorFIO = a.UserProfile?.FIO ?? "Unknown",
                    UserProfileId = a.UserProfileId
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching answers for question ID {QuestionId}", request.QuestionId);
                throw;
            }
        }
    }
}