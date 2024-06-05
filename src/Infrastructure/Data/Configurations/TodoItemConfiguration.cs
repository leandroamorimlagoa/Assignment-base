using Assignment.Domain.Constants;
using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Infrastructure.Data.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.ListId)
            .IsRequired();

        builder.Property(t => t.Title)
            .HasMaxLength(FieldsConfigurations.MaxLengthTitleFields)
            .IsRequired();

        builder.HasIndex(t => new { t.ListId, t.Title })
            .IsUnique();

        builder.HasOne(t => t.List)
            .WithMany(b => b.Items)
            .HasForeignKey(t => t.ListId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
