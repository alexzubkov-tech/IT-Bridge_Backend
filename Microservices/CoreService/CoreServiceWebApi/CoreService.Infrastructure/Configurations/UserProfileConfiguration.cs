using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(up => up.Id);

        builder.Property(up => up.Email).IsRequired();
        builder.Property(up => up.FIO).IsRequired();
        builder.Property(up => up.Bio);
        builder.Property(up => up.IsExpert);
        builder.Property(up => up.GitHubUrl);
        builder.Property(up => up.LinkedInUrl);
        builder.Property(up => up.ResumeUrl);

        builder.HasOne(up => up.Company)
               .WithMany(c => c.UserProfiles)
               .HasForeignKey(up => up.CompanyId);

        builder.Property(up => up.PositionId);
        builder.Property(up => up.ExperienceYears);
        builder.Property(up => up.TelegramId);
        builder.Property(up => up.CreatedAt);
        builder.Property(up => up.UpdatedAt);
    }
}