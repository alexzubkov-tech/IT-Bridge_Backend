using MediatR;

namespace CoreService.Application.RatingQuestions.Commands.DeleteRatingQuestionCommand
{
    public record DeleteRatingQuestionCommand(int Id) : IRequest<bool>;
}