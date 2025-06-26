using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CommentAnswerConfiguration : IEntityTypeConfiguration<CommentAnswer>
{
    public void Configure(EntityTypeBuilder<CommentAnswer> builder)
    {
        builder.HasKey(ca => ca.Id);

        builder.Property(ca => ca.Content).IsRequired();

        builder.HasOne(ca => ca.Answer)
               .WithMany(a => a.Comments)
               .HasForeignKey(ca => ca.AnswerId);

        builder.HasOne(ca => ca.ProfileUser)
               .WithMany(u => u.AnswerComments)
               .HasForeignKey(ca => ca.ProfileUserId);

        builder.Property(ca => ca.CreatedAt);
        builder.Property(ca => ca.UpdatedAt);
    }
}