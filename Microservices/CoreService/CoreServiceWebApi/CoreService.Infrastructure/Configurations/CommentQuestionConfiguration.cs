using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CommentQuestionConfiguration : IEntityTypeConfiguration<CommentQuestion>
{
    public void Configure(EntityTypeBuilder<CommentQuestion> builder)
    {
        builder.HasKey(cq => cq.Id);

        builder.Property(cq => cq.Content).IsRequired();

        builder.HasOne(cq => cq.Question)
               .WithMany(q => q.Comments)
               .HasForeignKey(cq => cq.QuestionId);

        builder.HasOne(cq => cq.ProfileUser)
               .WithMany(u => u.QuestionComments)
               .HasForeignKey(cq => cq.ProfileUserId);

        builder.Property(cq => cq.CreatedAt);
        builder.Property(cq => cq.UpdatedAt);
    }
}