using MediatR;
using CoreService.Application.Answers.Dtos;

namespace CoreService.Application.Answers.Queries.GetAllAnswersQuery
{
    public record GetAllAnswersQuery() : IRequest<IEnumerable<AnswerDto>>;
}