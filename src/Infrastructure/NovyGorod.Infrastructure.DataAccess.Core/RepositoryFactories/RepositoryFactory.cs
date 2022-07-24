using Autofac;
using NovyGorod.Domain.EntityAccess;

namespace NovyGorod.Infrastructure.DataAccess.Core.RepositoryFactories;

internal class RepositoryFactory : IRepositoryFactory
{
    private readonly ILifetimeScope _lifetimeScope;
    
    public RepositoryFactory(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }
    
    public IRepository<TEntity> GetGenericRepository<TEntity>()
        where TEntity : class
    {
        return _lifetimeScope.Resolve<IRepository<TEntity>>();
    }
    
    public TRepository GetRepository<TRepository, TEntity>()
        where TRepository : class, IRepository<TEntity>
        where TEntity : class
    {
        return _lifetimeScope.Resolve<TRepository>();
    }
}