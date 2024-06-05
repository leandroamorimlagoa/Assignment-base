using Assignment.Domain.Constants;
using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Infrastructure.Data.Configurations;
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .HasMaxLength(FieldsConfigurations.MaxLengthNameFields)
            .IsRequired();

        builder.Property(t => t.CountryId)
            .IsRequired();

        builder.HasIndex(t => new { t.CountryId, t.Name })
            .IsUnique();

        builder.HasOne(t => t.Country)
            .WithMany(t => t.Cities)
            .HasForeignKey(t => t.CountryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
