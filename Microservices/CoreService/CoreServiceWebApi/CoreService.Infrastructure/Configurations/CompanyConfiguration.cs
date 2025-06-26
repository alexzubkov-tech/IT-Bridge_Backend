using CoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.TaxId).IsRequired();
        builder.Property(c => c.Address).IsRequired();
        builder.Property(c => c.FoundationDate);
        builder.Property(c => c.EmployeeCount);
        builder.Property(c => c.Industry).IsRequired();
        builder.Property(c => c.PhoneNumber);
        builder.Property(c => c.CreatedAt);
        builder.Property(c => c.UpdatedAt);
    }
}