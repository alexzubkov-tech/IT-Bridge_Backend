using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class QuestionTagConfiguration : IEntityTypeConfiguration<QuestionTag>
{
    public void Configure(EntityTypeBuilder<QuestionTag> builder)
    {
        builder.HasKey(qt => new { qt.QuestionId, qt.TagId });

        builder.HasOne(qt => qt.Question)
               .WithMany()
               .HasForeignKey(qt => qt.QuestionId);

        builder.HasOne(qt => qt.Tag)
               .WithMany(t => t.QuestionTags)
               .HasForeignKey(qt => qt.TagId);

        builder.Property(qt => qt.CreatedAt);
        builder.Property(qt => qt.UpdatedAt);
    }
}