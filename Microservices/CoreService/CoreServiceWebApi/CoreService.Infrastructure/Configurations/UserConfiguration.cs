using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreService.Domain.Entities;

namespace CoreService.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.EmailConfirmed)
               .IsRequired();

        builder.Property(u => u.PasswordHash)
               .IsRequired();

        builder.Property(u => u.CreatedAt)
               .IsRequired();

        builder.Property(u => u.UpdatedAt)
               .IsRequired();

        // Связь 1 к 1 User -> UserProfile
        builder.HasOne(u => u.UserProfile)
               .WithOne(up => up.User)
               .HasForeignKey<User>(u => u.UserProfileId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
    }
}