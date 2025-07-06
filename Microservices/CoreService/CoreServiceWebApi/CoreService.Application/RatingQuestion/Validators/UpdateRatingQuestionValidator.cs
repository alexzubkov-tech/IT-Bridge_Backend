using CoreService.Application.RatingQuestions.Commands.UpdateRatingQuestionCommand;
using CoreService.Application.RatingQuestions.Dtos;
using FluentValidation;

namespace CoreService.Application.RatingQuestions.Validators
{
    public class UpdateRatingQuestionValidator : AbstractValidator<UpdateRatingQuestionCommand>
    {
        public UpdateRatingQuestionValidator()
        {
            RuleFor(x => x.Dto.IsGoodAnswer)
                .NotNull().WithMessage("IsGoodAnswer is required.")
                .Must(x => x == true || x == false).WithMessage("IsGoodAnswer must be either true or false.");
        }
    }
}