using CoreService.Application.Common.Interfaces;
using CoreService.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CoreService.Infrastructure
{
    public class CoreServiceDbContext : IdentityDbContext<User>, ICoreServiceDbContext
    {
        public CoreServiceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuestionCategory>()
                .HasKey(qc => new { qc.QuestionId, qc.CategoryId });

            modelBuilder.Entity<QuestionTag>()
                .HasKey(qc => new { qc.QuestionId, qc.TagId });

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId);
        }

    }
}
