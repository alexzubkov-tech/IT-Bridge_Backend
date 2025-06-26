using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.UserName).IsRequired();
        builder.Property(u => u.PasswordHash).IsRequired();

        builder.HasOne(u => u.UserProfile)
               .WithOne()
               .HasForeignKey<User>(u => u.UserProfileId);

        builder.Property(u => u.CreatedAt);
        builder.Property(u => u.UpdatedAt);
    }
}