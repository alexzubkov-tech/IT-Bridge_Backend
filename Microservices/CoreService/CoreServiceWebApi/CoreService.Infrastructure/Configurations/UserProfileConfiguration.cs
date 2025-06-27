using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreService.Domain.Entities;

namespace CoreService.Infrastructure.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(up => up.Id);

        builder.Property(up => up.UserName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(up => up.FIO)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(up => up.Bio)
               .HasMaxLength(500);

        builder.Property(up => up.IsExpert)
               .IsRequired();

        builder.Property(up => up.GitHubUrl)
               .HasMaxLength(200);

        builder.Property(up => up.LinkedInUrl)
               .HasMaxLength(200);

        builder.Property(up => up.ResumeUrl)
               .HasMaxLength(200);

        builder.Property(up => up.PositionId)
               .IsRequired();

        builder.Property(up => up.ExperienceYears)
               .IsRequired();

        builder.Property(up => up.TelegramId)
               .HasMaxLength(50);

        builder.Property(up => up.CreatedAt)
               .IsRequired();

        builder.Property(up => up.UpdatedAt)
               .IsRequired();

        builder.HasOne(up => up.Company)
               .WithMany(c => c.UserProfiles)
               .HasForeignKey(up => up.CompanyId);
    }
}