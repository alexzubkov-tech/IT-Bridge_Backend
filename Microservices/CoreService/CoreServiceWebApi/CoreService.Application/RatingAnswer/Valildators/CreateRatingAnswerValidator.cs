using CoreService.Application.RatingAnswers.Commands.CreateRatingAnswerCommand;
using CoreService.Domain.Interfaces;
using FluentValidation;

namespace CoreService.Application.RatingAnswers.Validators
{
    public class CreateRatingAnswerValidator : AbstractValidator<CreateRatingAnswerCommand>
    {
        private readonly IRatingAnswerRepository _ratingAnswerRepository;
        private readonly IEntityExistenceChecker _existenceChecker;

        public CreateRatingAnswerValidator(
            IEntityExistenceChecker existenceChecker,
            IRatingAnswerRepository ratingAnswerRepository)
        {
            _existenceChecker = existenceChecker;
            _ratingAnswerRepository = ratingAnswerRepository;

            RuleFor(x => x.Dto.IsGoodAnswer)
                .NotNull().WithMessage("IsGoodAnswer is required.")
                .Must(x => x == true || x == false)
                .WithMessage("IsGoodAnswer must be either true or false.");

            RuleFor(x => x.Dto.UserProfileId)
                .NotEmpty().WithMessage("UserProfileId is required.")
                .GreaterThan(0).WithMessage("UserProfileId must be greater than zero.")
                .MustAsync(async (id, ct) => await _existenceChecker.UserProfileExists(id))
                .WithMessage("UserProfile with the given ID does not exist.");

            RuleFor(x => x.Dto.AnswerId)
                .NotEmpty().WithMessage("AnswerId is required.")
                .GreaterThan(0).WithMessage("AnswerId must be greater than zero.")
                .MustAsync(async (id, ct) => await _existenceChecker.AnswerExists(id))
                .WithMessage("Answer with the given ID does not exist.");

            RuleFor(x => new { x.Dto.UserProfileId, x.Dto.AnswerId })
                .MustAsync(async (ids, ct) =>
                    !await _ratingAnswerRepository.HasUserAlreadyRatedAnswer(ids.UserProfileId, ids.AnswerId, ct))
                .WithMessage("You have already rated this answer.");
        }
    }
}