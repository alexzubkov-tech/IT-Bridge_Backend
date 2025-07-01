

using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.CommentQuestions.Mapper;
using CoreService.Application.Common.Interfaces;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Questions.Queries.GetQuestionCommentQuestionsQuery
{
    public class GetQuestionCommentQuestionsQueryHandler : IRequestHandler<GetQuestionCommentQuestionsQuery, IEnumerable<CommentQuestionDto>>
    {
        private readonly ICoreServiceDbContext _context;
        private readonly ICommentQuestionRepository _commentQuestionRepository;

        public GetQuestionCommentQuestionsQueryHandler(ICoreServiceDbContext context, ICommentQuestionRepository commentQuestionRepository)
        {
            _context = context;
            _commentQuestionRepository = commentQuestionRepository;
        }

        public async Task<IEnumerable<CommentQuestionDto>> Handle(GetQuestionCommentQuestionsQuery request, CancellationToken ct)
        {

            var commentQuestion = await _commentQuestionRepository.GetAllToQuestionAsync(request.Id);
            if (commentQuestion == null)
                throw new KeyNotFoundException($"Question with ID {request.Id} not found.");

            return commentQuestion.Select(r => r.ToDto());
        }
    }
}
