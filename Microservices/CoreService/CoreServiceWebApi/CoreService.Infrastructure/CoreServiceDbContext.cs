using CoreService.Application.Common.Interfaces;
using CoreService.Domain.Entities;
using CoreService.Infrastructure.Configurations;
using CoreService.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Infrastructure
{
    public class CoreServiceDbContext : DbContext, ICoreServiceDbContext
    {
        public CoreServiceDbContext(DbContextOptions<CoreServiceDbContext> options) : base(options) { }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerRating> AnswerRatings { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryQuestion> CategoryQuestions { get; set; }
        public DbSet<CommentAnswer> CommentAnswers { get; set; }
        public DbSet<CommentQuestion> CommentQuestions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionRating> QuestionRatings { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerRatingConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new CommentAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new CommentQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionRatingConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionTagConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}
