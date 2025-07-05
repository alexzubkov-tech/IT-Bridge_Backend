using CoreService.Application.UserProfiles.Commands.UpdateUserProfileCommand;
using FluentValidation;

namespace CoreService.Application.UserProfiles.Validators
{
    public class UpdateUserProfileValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileValidator()
        {
            RuleFor(x => x.Dto.FIO)
                .NotEmpty().WithMessage("FIO is required.");

            RuleFor(x => x.Dto.Bio)
                .NotEmpty().WithMessage("Bio is required.")
                .MinimumLength(5).WithMessage("Bio must be at least 5 characters long.");
        }
    }
}