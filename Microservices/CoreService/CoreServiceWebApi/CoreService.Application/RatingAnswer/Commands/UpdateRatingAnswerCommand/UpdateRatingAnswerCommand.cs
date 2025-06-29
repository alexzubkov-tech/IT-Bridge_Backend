using MediatR;
using CoreService.Application.RatingAnswers.Dtos;

namespace CoreService.Application.RatingAnswers.Commands.UpdateRatingAnswerCommand
{
    public record UpdateRatingAnswerCommand(int Id, UpdateRatingAnswerDto Dto) : IRequest<RatingAnswerDto>;
}