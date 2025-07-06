using CoreService.Application.CommentAnswers.Dtos;
using CoreService.Application.CommentAnswers.Mapper;
using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.CommentQuestions.Mapper;
using CoreService.Application.CommentQuestions.Queries.GetQuestionCommentQuestionsQuery;
using CoreService.Application.Common.Interfaces;
using CoreService.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Application.CommentAnswers.Queries.GetCommentAnswersToAnswerQuery
{
    public class GetCommentAnswersToAnswerQueryHandler : IRequestHandler<GetCommentAnswersToAnswerQuery, IEnumerable<CommentAnswerDto>>
    {
        private readonly ICoreServiceDbContext _context;
        private readonly ICommentAnswerRepository _commentAnswerRepository;

        public GetCommentAnswersToAnswerQueryHandler(ICoreServiceDbContext context, ICommentAnswerRepository commentAnswerRepository)
        {
            _context = context;
            _commentAnswerRepository = commentAnswerRepository;
        }

        public async Task<IEnumerable<CommentAnswerDto>> Handle(GetCommentAnswersToAnswerQuery request, CancellationToken ct)
        {

            var commentAnswer = await _commentAnswerRepository.GetAllToAnswerAsync(request.answerId);
            if (commentAnswer == null)
                throw new KeyNotFoundException($"Question with ID {request.answerId} not found.");

            return commentAnswer.Select(r => r.ToDto());
        }

    }

}
