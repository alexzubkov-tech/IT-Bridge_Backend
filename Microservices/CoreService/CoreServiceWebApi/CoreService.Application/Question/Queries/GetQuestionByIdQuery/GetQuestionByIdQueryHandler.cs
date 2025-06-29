using CoreService.Application.Questions.Dtos;
using CoreService.Application.Questions.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Questions.Queries.GetQuestionByIdQuery
{
    public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, QuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionByIdQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionDto> Handle(GetQuestionByIdQuery request, CancellationToken ct)
        {
            var question = await _questionRepository.GetByIdAsync(request.Id, ct);
            if (question == null)
                throw new KeyNotFoundException($"Question with ID {request.Id} not found.");

            return question.ToDto();
        }
    }
}