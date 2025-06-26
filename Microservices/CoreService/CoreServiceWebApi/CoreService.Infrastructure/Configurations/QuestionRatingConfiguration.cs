using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class QuestionRatingConfiguration : IEntityTypeConfiguration<QuestionRating>
{
    public void Configure(EntityTypeBuilder<QuestionRating> builder)
    {
        builder.HasKey(qr => qr.Id);

        builder.HasOne(qr => qr.ProfileUser)
               .WithMany(u => u.QuestionRatings)
               .HasForeignKey(qr => qr.ProfileUserId);

        builder.HasOne(qr => qr.Question)
               .WithMany(q => q.Ratings)
               .HasForeignKey(qr => qr.QuestionId);

        builder.Property(qr => qr.CreatedAt);
        builder.Property(qr => qr.UpdatedAt);
    }
}