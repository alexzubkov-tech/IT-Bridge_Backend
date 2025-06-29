using CoreService.Application.RatingQuestions.Dtos;
using MediatR;

namespace CoreService.Application.RatingQuestions.Commands.UpdateRatingQuestionCommand
{
    public record UpdateRatingQuestionCommand(int Id, UpdateRatingQuestionDto Dto) : IRequest<RatingQuestionDto>;
}