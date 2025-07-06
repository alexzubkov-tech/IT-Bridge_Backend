using CoreService.Application.RatingQuestions.Dtos;
using MediatR;

namespace CoreService.Application.RatingQuestions.Commands.CreateRatingQuestionCommand
{
    public record CreateRatingQuestionCommand(CreateRatingQuestionDto Dto) : IRequest<RatingQuestionDto>;
}