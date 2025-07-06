using CoreService.Application.Answers.Commands.UpdateAnswerCommand;
using CoreService.Application.Answers.Dtos;
using CoreService.Domain.Interfaces;
using FluentValidation;

namespace CoreService.Application.Answers.Validators
{
    public class UpdateAnswerValidator : AbstractValidator<UpdateAnswerCommand>
    {
        private readonly IEntityExistenceChecker _existenceChecker;

        public UpdateAnswerValidator(IEntityExistenceChecker existenceChecker)
        {
            _existenceChecker = existenceChecker;

            RuleFor(x => x.Dto.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MinimumLength(5).WithMessage("Content must be at least 5 characters long.")
                .MaximumLength(5000).WithMessage("Content cannot exceed 5000 characters.");

            RuleFor(x => x.Dto.UserProfileId)
                .GreaterThan(0).WithMessage("UserProfileId must be greater than zero.")
                .MustAsync(async (id, ct) => await _existenceChecker.UserProfileExists(id))
                .WithMessage("UserProfile with the given ID does not exist.");

            RuleFor(x => x.Dto.QuestionId)
                .GreaterThan(0).WithMessage("QuestionId must be greater than zero.")
                .MustAsync(async (id, ct) => await _existenceChecker.QuestionExists(id))
                .WithMessage("Question with the given ID does not exist.");
        }
    }
}