using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Application.Common.Interfaces
{
    public interface ICoreServiceDbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CommentAnswer> CommentAnswers { get; set; }
        public DbSet<CommentQuestion> CommentQuestions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<RatingAnswer> RatingAnswers { get; set; }
        public DbSet<RatingQuestion> RatingQuestion { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
