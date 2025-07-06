using CoreService.Application.UserProfiles.Commands.UpdateUserProfileCommand;
using CoreService.Domain.Interfaces;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace CoreService.Application.UserProfiles.Validators
{
    public class UpdateUserProfileValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileValidator(
            ICategoryRepository categoryRepository,
            ICompanyRepository companyRepository)
        {
            RuleFor(x => x.Dto.FIO)
                .NotEmpty().WithMessage("FIO is required.")
                .Length(5, 100).WithMessage("FIO must be between 5 and 100 characters.");

            RuleFor(x => x.Dto.Bio)
                .MaximumLength(310).WithMessage("Bio cannot exceed 310 characters.");

            RuleFor(x => x.Dto.GithubUrl)
                .Must(BeValidUrlOrEmpty)
                .WithMessage("GithubUrl must be a valid URL or empty.");

            RuleFor(x => x.Dto.LinkedinUrl)
                .Must(BeValidUrlOrEmpty)
                .WithMessage("LinkedinUrl must be a valid URL or empty.");

            RuleFor(x => x.Dto.ResumeLink)
                .Must(BeValidUrlOrEmpty)
                .WithMessage("ResumeLink must be a valid URL or empty.");

            RuleFor(x => x.Dto.TelegramId)
                .MaximumLength(100).WithMessage("TelegramId cannot exceed 100 characters.")
                .Must(x => string.IsNullOrWhiteSpace(x) || !x.Contains(" "))
                .WithMessage("TelegramId must not contain spaces or must be empty.");

            RuleFor(x => x.Dto.ExperienceYears)
                .InclusiveBetween(0, 50)
                .When(x => x.Dto.ExperienceYears.HasValue)
                .WithMessage("ExperienceYears must be between 0 and 50.");

            RuleFor(x => x.Dto.Position)
                .NotNull()
                .WithMessage("Position is required.");

            RuleFor(x => x.Dto.CategoryId)
                .MustAsync(async (categoryId, ct) =>
                {
                    if (!categoryId.HasValue) return true;
                    return await categoryRepository.CategoryExists(categoryId.Value);
                })
                .WithMessage("Category with the given ID does not exist.");

            RuleFor(x => x.Dto.CompanyId)
                .MustAsync(async (companyId, ct) =>
                {
                    if (!companyId.HasValue) return true;
                    return await companyRepository.CompanyExists(companyId.Value);
                })
                .WithMessage("Company with the given ID does not exist.");
        }

        // Проверка: пустая строка или валидный URL
        private bool BeValidUrlOrEmpty(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return true;

            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}