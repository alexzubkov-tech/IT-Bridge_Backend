using CoreService.Application.RatingAnswers.Commands.CreateRatingAnswerCommand;
using CoreService.Application.RatingQuestions.Commands.CreateRatingQuestionCommand;
using CoreService.Application.RatingQuestions.Dtos;
using CoreService.Domain.Interfaces;
using FluentValidation;

namespace CoreService.Application.RatingQuestions.Validators
{
    public class CreateRatingQuestionValidator : AbstractValidator<CreateRatingQuestionCommand>
    {
        private readonly IRatingQuestionRepository _ratingQuestionRepository;
        public CreateRatingQuestionValidator(IEntityExistenceChecker existenceChecker, IRatingQuestionRepository ratingQuestionRepository)
        {
            _ratingQuestionRepository = ratingQuestionRepository;

            RuleFor(x => x.Dto.IsGoodAnswer)
                .NotNull().WithMessage("IsGoodAnswer is required.")
                .Must(x => x == true || x == false)
                .WithMessage("IsGoodAnswer must be either true or false.");

            RuleFor(x => x.Dto.UserProfileId)
                .NotEmpty().WithMessage("UserProfileId is required.")
                .GreaterThan(0).WithMessage("UserProfileId must be greater than zero.")
                .MustAsync(async (id, ct) => await existenceChecker.UserProfileExists(id))
                .WithMessage("UserProfile with the given ID does not exist.");

            RuleFor(x => x.Dto.QuestionId)
                .NotEmpty().WithMessage("QuestionId is required.")
                .GreaterThan(0).WithMessage("QuestionId must be greater than zero.")
                .MustAsync(async (id, ct) => await existenceChecker.QuestionExists(id))
                .WithMessage("Question with the given ID does not exist.");

            RuleFor(x => new { x.Dto.UserProfileId, x.Dto.QuestionId })
                .MustAsync(async (ids, ct) =>
                {
                    var exists = await _ratingQuestionRepository.HasUserAlreadyRatedQuestion(ids.UserProfileId, ids.QuestionId, ct);
                    return !exists;
                })
                .WithMessage("You have already rated this question.");
        }
    }
}