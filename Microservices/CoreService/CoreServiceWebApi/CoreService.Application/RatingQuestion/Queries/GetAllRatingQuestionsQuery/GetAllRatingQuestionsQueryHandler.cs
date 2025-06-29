using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.RatingQuestions.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.RatingQuestions.Queries.GetAllRatingQuestionsQuery
{
    public class GetAllRatingQuestionsQueryHandler : IRequestHandler<GetAllRatingQuestionsQuery, IEnumerable<RatingQuestionDto>>
    {
        private readonly IRatingQuestionRepository _repo;

        public GetAllRatingQuestionsQueryHandler(IRatingQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<RatingQuestionDto>> Handle(GetAllRatingQuestionsQuery request, CancellationToken ct)
        {
            var ratings = await _repo.GetAllAsync();
            return ratings.Select(r => r.ToDto());
        }
    }
}