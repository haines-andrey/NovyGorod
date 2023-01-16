namespace NovyGorod.DbSeeder.EntityFactories;

internal interface IEntityFactory<TEntity, in TDto>
{
    Task<TEntity> Create(TDto dto);
}