using CoreService.Application.RatingAnswers.Commands.UpdateRatingAnswerCommand;
using FluentValidation;

namespace CoreService.Application.RatingAnswers.Validators
{
    public class UpdateRatingAnswerValidator : AbstractValidator<UpdateRatingAnswerCommand>
    {
        public UpdateRatingAnswerValidator()
        {
            RuleFor(x => x.Dto.IsGoodAnswer)
                .NotNull().WithMessage("IsGoodAnswer is required.")
                .Must(x => x == true || x == false)
                .WithMessage("IsGoodAnswer must be either true or false.");
        }
    }
}