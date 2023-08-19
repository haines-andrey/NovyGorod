using NovyGorod.Domain.ModelAccess;

namespace NovyGorod.Infrastructure.DataAccess.Core.RepositoryFactories;

public interface IRepositoryFactory
{
    IRepository<TEntity> GetGenericRepository<TEntity>()
        where TEntity : class;

    TRepository GetRepository<TRepository, TEntity>()
        where TRepository : class, IRepository<TEntity>
        where TEntity : class;
}