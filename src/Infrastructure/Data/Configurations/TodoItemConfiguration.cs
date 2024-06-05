using Assignment.Domain.Constants;
using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Infrastructure.Data.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(FieldsConfigurations.MaxLengthTitleFields)
            .IsRequired();

        builder.HasIndex(t => t.Title)
            .IsUnique();
    }
}
