using CoreService.Application.Common.Interfaces;
using CoreService.Application.RatingAnswers.Dtos;
using CoreService.Application.RatingAnswers.Mapper;
using CoreService.Application.RatingQuestions.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.RatingAnswers.Queries.GetRatingAnswerToAnswerQuery
{
    public class GetRatingAnswerToAnswerQueryHandler :  IRequestHandler<GetRatingAnswerToAnswerQuery, IEnumerable<RatingAnswerDto>>
    {
        private readonly ICoreServiceDbContext _context;
        private readonly IRatingAnswerRepository _ratingAnswerRepository;

        public GetRatingAnswerToAnswerQueryHandler(ICoreServiceDbContext context, IRatingAnswerRepository ratingAnswerRepository)
        {
            _context = context;
            _ratingAnswerRepository = ratingAnswerRepository;
        }

        public async Task<IEnumerable<RatingAnswerDto>> Handle(GetRatingAnswerToAnswerQuery request, CancellationToken ct)
        {

            var ratingQuestion = await _ratingAnswerRepository.GetAllToAnswerAsync(request.answerId);
            if (ratingQuestion == null)
                throw new KeyNotFoundException($"Question with ID {request.answerId} not found.");

            return ratingQuestion.Select(r => r.ToDto());
        }
    }
}
