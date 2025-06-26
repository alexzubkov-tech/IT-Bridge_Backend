using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AnswerRatingConfiguration : IEntityTypeConfiguration<AnswerRating>
{
    public void Configure(EntityTypeBuilder<AnswerRating> builder)
    {
        builder.HasKey(ar => ar.Id);

        builder.HasOne(ar => ar.ProfileUser)
               .WithMany(u => u.AnswerRatings)
               .HasForeignKey(ar => ar.ProfileUserId);

        builder.HasOne(ar => ar.Answer)
               .WithMany(a => a.Ratings)
               .HasForeignKey(ar => ar.AnswerId);

        builder.Property(ar => ar.CreatedAt);
        builder.Property(ar => ar.UpdatedAt);
    }
}