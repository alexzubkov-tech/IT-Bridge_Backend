using CoreService.Application.Tags.Commands.CreateTagCommand;
using FluentValidation;

public class CreateTagValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagValidator(ITagRepository tagRepository)
    {
        RuleFor(x => x.Dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage("Name cannot be empty or consist of whitespace only.")
            .MustAsync(async (name, ct) =>
            {
                return !(await tagRepository.TagExistsWithName(name, ct));
            })
            .WithMessage("A tag with this name already exists.");
    }
}