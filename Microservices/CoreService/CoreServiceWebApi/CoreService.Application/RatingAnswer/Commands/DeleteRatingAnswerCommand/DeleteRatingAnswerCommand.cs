using MediatR;

namespace CoreService.Application.RatingAnswers.Commands.DeleteRatingAnswerCommand
{
    public record DeleteRatingAnswerCommand(int Id) : IRequest<bool>;
}