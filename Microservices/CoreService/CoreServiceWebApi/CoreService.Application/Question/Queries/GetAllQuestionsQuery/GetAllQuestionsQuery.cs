using CoreService.Application.Questions.Dtos;
using MediatR;

namespace CoreService.Application.Questions.Queries.GetAllQuestionsQuery
{
    public record GetAllQuestionsQuery() : IRequest<IEnumerable<QuestionDto>>;
}