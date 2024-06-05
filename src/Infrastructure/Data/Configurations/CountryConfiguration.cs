using Assignment.Domain.Constants;
using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Infrastructure.Data.Configurations;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .HasMaxLength(FieldsConfigurations.MaxLengthNameFields)
            .IsRequired();

        builder.HasIndex(t => t.Name)
            .IsUnique();
    }
}
