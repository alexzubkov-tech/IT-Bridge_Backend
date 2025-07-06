using CoreService.Application.Questions.Dtos;
using CoreService.Application.Questions.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Questions.Queries.GetAllQuestionsQuery
{
    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, IEnumerable<QuestionDto>>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetAllQuestionsQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<IEnumerable<QuestionDto>> Handle(GetAllQuestionsQuery request, CancellationToken ct)
        {
            var questions = await _questionRepository.GetAllAsync(ct, request.Title?.Trim());
            return questions.Select(q => q.ToDto());
        }
    }
}