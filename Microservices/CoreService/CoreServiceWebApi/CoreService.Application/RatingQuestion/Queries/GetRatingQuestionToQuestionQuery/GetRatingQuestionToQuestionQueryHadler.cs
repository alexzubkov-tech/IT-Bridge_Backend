using CoreService.Application.Common.Interfaces;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Application.RatingQuestions.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Application.RatingQuestions.Queries.GetQuestionRatingQuestionsQuery
{
    public class GetRatingQuestionToQuestionQueryHadler : IRequestHandler<GetRatingQuestionToQuestionQuery, IEnumerable<RatingQuestionDto>>
    {
        private readonly IRatingQuestionRepository _ratingQuestionRepository;

        public GetRatingQuestionToQuestionQueryHadler(ICoreServiceDbContext context, IRatingQuestionRepository ratingQuestionRepository)
        {
            _ratingQuestionRepository = ratingQuestionRepository;
        }

        public async Task<IEnumerable<RatingQuestionDto>> Handle(GetRatingQuestionToQuestionQuery request, CancellationToken ct)
        {

            var ratingQuestion = await _ratingQuestionRepository.GetAllToQuestionAsync(request.qustionId);
            if (ratingQuestion == null)
                throw new KeyNotFoundException($"Question with ID {request.qustionId} not found.");

            return ratingQuestion.Select(r => r.ToDto());
        }

    }
}
