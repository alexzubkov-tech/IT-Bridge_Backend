using CoreService.Application.CommentQuestions.Dtos;
using CoreService.Application.CommentQuestions.Mapper;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.CommentQuestions.Queries.GetCommentQuestionByIdQuery
{
    public class GetCommentQuestionByIdQueryHandler : IRequestHandler<GetCommentQuestionByIdQuery, CommentQuestionDto>
    {
        private readonly ICommentQuestionRepository _repo;

        public GetCommentQuestionByIdQueryHandler(ICommentQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<CommentQuestionDto> Handle(GetCommentQuestionByIdQuery request, CancellationToken ct)
        {
            var comment = await _repo.GetByIdAsync(request.Id);
            if (comment == null)
                throw new KeyNotFoundException("Comment not found");

            return comment.ToDto();
        }
    }
}