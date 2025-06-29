using CoreService.Application.Questions.Dtos;
using MediatR;

namespace CoreService.Application.Questions.Queries.GetQuestionByIdQuery
{
    public record GetQuestionByIdQuery(int Id) : IRequest<QuestionDto>;
}