using CoreService.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CoreService.Application.UserProfiles.Dtos
{
    public class UpdateUserProfileDto : IValidatableObject
    {
        [Required(ErrorMessage = "FIO is required.")]
        [MinLength(3, ErrorMessage = "FIO must be at least 3 characters.")]
        [MaxLength(200, ErrorMessage = "FIO cannot exceed 200 characters.")]
        public string FIO { get; set; }

        [MaxLength(310, ErrorMessage = "Bio cannot exceed 310 characters.")]
        public string Bio { get; set; }

        [UrlIfNotEmpty("GithubUrl must be a valid URL.")]
        public string GithubUrl { get; set; }

        [UrlIfNotEmpty("LinkedinUrl must be a valid URL.")]
        public string LinkedinUrl { get; set; }

        [UrlIfNotEmpty("ResumeLink must be a valid URL.")]
        public string ResumeLink { get; set; }

        [MaxLength(100, ErrorMessage = "TelegramId cannot exceed 100 characters.")]
        public string TelegramId { get; set; }

        [Range(0, 100, ErrorMessage = "ExperienceYears must be between 0 and 100.")]
        public int? ExperienceYears { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        public Position Position { get; set; }

        public int? CompanyId { get; set; }
        public int? CategoryId { get; set; }

        public bool IsExpert { get; set; }

        // Бизнес-валидация через репозитории
        public async Task Validate(ICategoryRepository categoryRepository, ICompanyRepository companyRepository, List<ValidationResult> errors)
        {
            if (CompanyId.HasValue && !(await companyRepository.CompanyExists(CompanyId.Value)))
            {
                errors.Add(new ValidationResult("Company with this ID does not exist.", new[] { nameof(CompanyId) }));
            }

            if (CategoryId.HasValue && !(await categoryRepository.CategoryExists(CategoryId.Value)))
            {
                errors.Add(new ValidationResult("Category with this ID does not exist.", new[] { nameof(CategoryId) }));
            }
        }

        // Вызывается автоматически при стандартной валидации
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}