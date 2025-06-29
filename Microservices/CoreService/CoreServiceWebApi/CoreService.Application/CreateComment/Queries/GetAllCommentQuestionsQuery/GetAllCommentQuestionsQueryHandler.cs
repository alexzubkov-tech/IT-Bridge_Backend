using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.CommentQuestions.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.CommentQuestions.Queries.GetAllCommentQuestionsQuery
{
    public class GetAllCommentQuestionsQueryHandler : IRequestHandler<GetAllCommentQuestionsQuery, IEnumerable<CommentQuestionDto>>
    {
        private readonly ICommentQuestionRepository _repo;

        public GetAllCommentQuestionsQueryHandler(ICommentQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CommentQuestionDto>> Handle(GetAllCommentQuestionsQuery request, CancellationToken ct)
        {
            var comments = await _repo.GetAllAsync();
            return comments.Select(c => c.ToDto());
        }
    }
}