using Assignment.Domain.Constants;
using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Infrastructure.Data.Configurations;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(FieldsConfigurations.MaxLengthTitleFields)
            .IsRequired();

        builder.HasIndex(t => t.Title)
            .IsUnique();

        builder
            .OwnsOne(b => b.Colour);
    }
}
