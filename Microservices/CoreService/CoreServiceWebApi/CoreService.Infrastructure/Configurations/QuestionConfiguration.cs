using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Title).IsRequired();
        builder.Property(q => q.Content).IsRequired();

        builder.HasOne(q => q.ProfileUser)
               .WithMany(u => u.Questions)
               .HasForeignKey(q => q.ProfileUserId);

        builder.Property(q => q.IsUrgent);
        builder.Property(q => q.ViewCount);
        builder.Property(q => q.CreatedAt);
        builder.Property(q => q.UpdatedAt);
    }
}