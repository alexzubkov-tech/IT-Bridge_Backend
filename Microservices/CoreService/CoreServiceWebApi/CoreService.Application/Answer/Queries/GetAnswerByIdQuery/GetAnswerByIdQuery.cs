using MediatR;
using CoreService.Application.Answers.Dtos;

namespace CoreService.Application.Answers.Queries.GetAnswerByIdQuery
{
    public record GetAnswerByIdQuery(int Id) : IRequest<AnswerDto>;
}