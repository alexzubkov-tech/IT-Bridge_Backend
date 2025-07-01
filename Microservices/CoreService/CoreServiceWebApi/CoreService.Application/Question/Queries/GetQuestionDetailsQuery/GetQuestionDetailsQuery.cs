using MediatR;
using CoreService.Application.Questions.Dtos;

namespace CoreService.Application.Questions.Queries.GetQuestionDetailsQuery
{
    public record GetQuestionDetailsQuery(int Id) : IRequest<QuestionDetailsDto>;
}