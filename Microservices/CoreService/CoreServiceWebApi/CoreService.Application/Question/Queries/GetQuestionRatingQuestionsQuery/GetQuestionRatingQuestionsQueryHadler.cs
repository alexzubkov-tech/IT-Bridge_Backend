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

namespace CoreService.Application.Questions.Queries.GetQuestionRatingQuestionQuery
{
    public class GetQuestionRatingQuestionsQueryHadler : IRequestHandler<GetQuestionRatingQuestionsQuery, IEnumerable<RatingQuestionDto>>
    {
        private readonly ICoreServiceDbContext _context;
        private readonly IRatingQuestionRepository _ratingQuestionRepository;

        public GetQuestionRatingQuestionsQueryHadler(ICoreServiceDbContext context, IRatingQuestionRepository ratingQuestionRepository)
        {
            _context = context;
            _ratingQuestionRepository = ratingQuestionRepository;
        }

        public async Task<IEnumerable<RatingQuestionDto>> Handle(GetQuestionRatingQuestionsQuery request, CancellationToken ct)
        {

            var ratingQuestion = await _ratingQuestionRepository.GetAllToQuestionAsync(request.Id);
            if (ratingQuestion == null)
                throw new KeyNotFoundException($"Question with ID {request.Id} not found.");

            return ratingQuestion.Select(r => r.ToDto());
        }

    }
}
