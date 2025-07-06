using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.RatingQuestions.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.RatingQuestions.Queries.GetRatingQuestionByIdQuery
{
    public class GetRatingQuestionByIdQueryHandler : IRequestHandler<GetRatingQuestionByIdQuery, RatingQuestionDto>
    {
        private readonly IRatingQuestionRepository _repo;

        public GetRatingQuestionByIdQueryHandler(IRatingQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<RatingQuestionDto> Handle(GetRatingQuestionByIdQuery request, CancellationToken ct)
        {
            var rating = await _repo.GetByIdAsync(request.Id);
            if (rating == null)
                throw new KeyNotFoundException("Rating not found");

            return rating.ToDto();
        }
    }
}