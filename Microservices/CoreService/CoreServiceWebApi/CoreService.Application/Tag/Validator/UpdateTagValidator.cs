using CoreService.Application.Tags.Commands.UpdateTagCommand;
using FluentValidation;

namespace CoreService.Application.Tags.Validators
{
    public class UpdateTagValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagValidator(ITagRepository tagRepository)
        {
            RuleFor(x => x.Dto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithMessage("Name cannot be empty or consist of whitespace only.")
                .MustAsync(async (name, ct) =>
                {
                    return !(await tagRepository.TagExistsWithName(name));
                })
                .WithMessage("A tag with this name already exists.");
        }
    }
}