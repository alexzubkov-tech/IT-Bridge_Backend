using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Application.Common.Interfaces
{
    public interface ICoreServiceDbContext
    {
        DbSet<Answer> Answers { get; set; }
        DbSet<AnswerRating> AnswerRatings { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<CategoryQuestion> CategoryQuestions { get; set; }
        DbSet<CommentAnswer> CommentAnswers { get; set; }
        DbSet<CommentQuestion> CommentQuestions { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<QuestionRating> QuestionRatings { get; set; }
        DbSet<QuestionTag> QuestionTags { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserProfile> UserProfiles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
