using MediatR;
using CoreService.Application.RatingAnswers.Dtos;

namespace CoreService.Application.RatingAnswers.Commands.CreateRatingAnswerCommand
{
    public record CreateRatingAnswerCommand(CreateRatingAnswerDto Dto) : IRequest<RatingAnswerDto>;
}