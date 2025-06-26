using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreService.Domain.Entities;

namespace CoreService.Infrastructure.Persistence.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Content).IsRequired();

            builder.HasOne(a => a.Question)
                   .WithMany(q => q.Answers)
                   .HasForeignKey(a => a.QuestionId);

            builder.HasOne(a => a.ProfileUser)
                   .WithMany(u => u.Answers)
                   .HasForeignKey(a => a.ProfileUserId);

            builder.Property(a => a.CreatedAt);
            builder.Property(a => a.UpdatedAt);
        }
    }
}