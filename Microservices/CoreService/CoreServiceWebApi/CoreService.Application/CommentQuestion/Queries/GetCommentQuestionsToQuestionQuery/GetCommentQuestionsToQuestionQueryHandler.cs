using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.CommentQuestions.Mapper;
using CoreService.Application.Common.Interfaces;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.CommentQuestions.Queries.GetQuestionCommentQuestionsQuery
{
    public class GetCommentQuestionsToQuestionQueryHandler : IRequestHandler<GetCommentQuestionsToQuestionQuery, IEnumerable<CommentQuestionDto>>
    {
        private readonly ICoreServiceDbContext _context;
        private readonly ICommentQuestionRepository _commentQuestionRepository;

        public GetCommentQuestionsToQuestionQueryHandler(ICoreServiceDbContext context, ICommentQuestionRepository commentQuestionRepository)
        {
            _context = context;
            _commentQuestionRepository = commentQuestionRepository;
        }

        public async Task<IEnumerable<CommentQuestionDto>> Handle(GetCommentQuestionsToQuestionQuery request, CancellationToken ct)
        {

            var commentQuestion = await _commentQuestionRepository.GetAllToQuestionAsync(request.questionId);
            if (commentQuestion == null)
                throw new KeyNotFoundException($"Question with ID {request.questionId} not found.");

            return commentQuestion.Select(r => r.ToDto());
        }
    }
}
