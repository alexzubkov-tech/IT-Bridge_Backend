using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryQuestionConfiguration : IEntityTypeConfiguration<CategoryQuestion>
{
    public void Configure(EntityTypeBuilder<CategoryQuestion> builder)
    {
        builder.HasKey(cq => new { cq.QuestionId, cq.CategoryId });

        builder.HasOne(cq => cq.Question)
               .WithMany(q => q.CategoryQuestions)
               .HasForeignKey(cq => cq.QuestionId);

        builder.HasOne(cq => cq.Category)
               .WithMany(c => c.CategoryQuestions)
               .HasForeignKey(cq => cq.CategoryId);

        builder.Property(cq => cq.CreatedAt);
        builder.Property(cq => cq.UpdatedAt);
    }
}