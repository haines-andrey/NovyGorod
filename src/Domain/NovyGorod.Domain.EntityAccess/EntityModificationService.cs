using System.Diagnostics.CodeAnalysis;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.EntityAccess;

[ExcludeFromCodeCoverage]
internal class EntityModificationService<TEntity> : IEntityModificationService<TEntity>
    where TEntity : class, IBaseEntity
{
    private readonly IUnitOfWork _unitOfWork;

    public EntityModificationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public virtual Task<TEntity> Add(TEntity entity)
    {
        return _unitOfWork.Add(entity);
    }

    public Task AddRange(IEnumerable<TEntity> entities)
    {
        return _unitOfWork.AddRange(entities);
    }

    public Task<TEntity> Update(TEntity entity)
    {
        return _unitOfWork.Update(entity);
    }

    public Task UpdateRange(IEnumerable<TEntity> entities)
    {
        return _unitOfWork.UpdateRange(entities);
    }

    public Task Delete(TEntity entity)
    {
        return _unitOfWork.Delete(entity);
    }

    public Task DeleteRange(IEnumerable<TEntity> entities)
    {
        return _unitOfWork.DeleteRange(entities);
    }
}