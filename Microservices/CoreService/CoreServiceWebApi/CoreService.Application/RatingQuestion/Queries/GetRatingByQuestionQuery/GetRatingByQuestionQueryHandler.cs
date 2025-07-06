using CoreService.Application.Questions.Mapper;
using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.RatingQuestions.Queries.GetRatingByQuestion
{
    public class GetRatingByQuestionQueryHandler : IRequestHandler<GetRatingByQuestionQuery, IEnumerable<RatingByQuestionDto>>
    {
        private readonly IRatingQuestionRepository _ratingQuestionRepository;
        private readonly IQuestionRepository _questionRepository;

        public GetRatingByQuestionQueryHandler(
            IRatingQuestionRepository ratingQuestionRepository,
            IQuestionRepository questionRepository)
        {
            _ratingQuestionRepository = ratingQuestionRepository;
            _questionRepository = questionRepository;
        }

        public async Task<IEnumerable<RatingByQuestionDto>> Handle(GetRatingByQuestionQuery request, CancellationToken ct)
        {
            // Получаем все вопросы
            var questions = await _questionRepository.GetAllAsync(ct);

            // Получаем все рейтинги
            var ratings = await _ratingQuestionRepository.GetAllWithDetailsAsync();

            // Группируем рейтинги по QuestionId
            var ratingsGroupedByQuestion = ratings
                .GroupBy(r => r.QuestionId)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Формируем результаты
            var result = questions.Select(question =>
            {
                if (ratingsGroupedByQuestion.TryGetValue(question.Id, out var questionRatings))
                {
                    int positive = questionRatings.Count(r => r.IsGoodAnswer);
                    int negative = questionRatings.Count(r => !r.IsGoodAnswer);

                    return new RatingByQuestionDto
                    {
                        QuestionId = question.Id,
                        RatingPositive = positive,
                        RatingNegative = negative,
                        Question = question.ToDetailsDto()
                    };
                }
                else
                {
                    // Если нет рейтингов, возвращаем нули
                    return new RatingByQuestionDto
                    {
                        QuestionId = question.Id,
                        RatingPositive = 0,
                        RatingNegative = 0,
                        Question = question.ToDetailsDto()
                    };
                }
            }).ToList();

            // Дополнительно обновляем поля RatingPositive/Negative внутри Question.DetailsDto
            foreach (var item in result)
            {
                item.Question.RatingPositive = item.RatingPositive;
                item.Question.RatingNegative = item.RatingNegative;
            }

            return result;
        }
    }
}