using CoreService.Application.Questions.Commands.UpdateQuestionCommand;
using CoreService.Application.Questions.Dtos;
using CoreService.Domain.Interfaces;
using FluentValidation;

namespace CoreService.Application.Questions.Validators
{
    public class UpdateQuestionValidator : AbstractValidator<UpdateQuestionCommand>
    {
        private readonly IEntityExistenceChecker _existenceChecker;

        public UpdateQuestionValidator(IEntityExistenceChecker existenceChecker)
        {
            _existenceChecker = existenceChecker;

            RuleFor(x => x.Dto.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(5).WithMessage("Title must be at least 5 characters long.")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

            RuleFor(x => x.Dto.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MinimumLength(10).WithMessage("Content must be at least 10 characters long.")
                .MaximumLength(5000).WithMessage("Content cannot exceed 5000 characters.");

            RuleFor(x => x.Dto.CategoryIds)
                .NotEmpty().WithMessage("At least one category must be selected.")
                .Must(ids => ids.All(id => id > 0)).WithMessage("All CategoryIds must be greater than zero.")
                .Must(ids => ids.Distinct().Count() == ids.Count).WithMessage("CategoryIds must not contain duplicates.")
                .MustAsync(async (ids, ct) => await _existenceChecker.CategoriesExist(ids, ct))
                .WithMessage("One or more categories do not exist.");

            RuleFor(x => x.Dto.TagIds)
                .Must(ids => ids.Distinct().Count() == ids.Count).WithMessage("TagIds must not contain duplicates.")
                .When(x => x.Dto.TagIds != null && x.Dto.TagIds.Any())
                .MustAsync(async (ids, ct) => await _existenceChecker.TagsExist(ids, ct))
                .When(x => x.Dto.TagIds != null && x.Dto.TagIds.Any())
                .WithMessage("One or more tags do not exist.");
        }
    }
}