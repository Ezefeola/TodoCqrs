using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoCqrsApp.Domain.Models;

namespace TodoCqrsApp.Domain.Configurations
{
    public class TodoConfiguration : EntityTypeBaseConfiguration<Todo>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(x => x.Id);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<Todo> builder)
        {
            builder.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(30)
                .HasConversion<string>();

            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnUpdate();
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todos");
        }
    }
}
