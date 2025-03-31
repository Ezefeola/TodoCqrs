using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TodoCqrsApp.Domain.Models;

namespace TodoCqrsApp.Domain.Configurations
{
    public abstract class EntityTypeBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigurateProperties(builder);
            ConfigurateConstraints(builder);
            ConfigurateTableName(builder);
        }
        protected abstract void ConfigurateProperties(EntityTypeBuilder<T> builder);
        protected abstract void ConfigurateConstraints(EntityTypeBuilder<T> builder);
        protected abstract void ConfigurateTableName(EntityTypeBuilder<T> builder);
    }
}
