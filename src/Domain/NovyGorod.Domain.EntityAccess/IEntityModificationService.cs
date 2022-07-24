using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.EntityAccess;

public interface IEntityModificationService<TEntity>
    where TEntity : IBaseEntity
{
    Task<TEntity> Add(TEntity entity);

    Task AddRange(IEnumerable<TEntity> entities);

    Task<TEntity> Update(TEntity entity);

    Task UpdateRange(IEnumerable<TEntity> entities);

    Task Delete(TEntity entity);

    Task DeleteRange(IEnumerable<TEntity> entities);
}