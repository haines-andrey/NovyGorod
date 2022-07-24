using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NovyGorod.Infrastructure.ModelConfigs;

public abstract class EntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class
{
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);
}