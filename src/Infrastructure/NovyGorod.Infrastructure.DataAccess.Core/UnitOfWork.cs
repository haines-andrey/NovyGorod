using System.Linq.Expressions;
using NovyGorod.Common.Extensions;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Results;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Infrastructure.DataAccess.Core.BeforeCommitHandlers;
using NovyGorod.Infrastructure.DataAccess.Core.RepositoryFactories;

namespace NovyGorod.Infrastructure.DataAccess.Core;

internal class UnitOfWork : IUnitOfWork
{
    private readonly IDataAccessProvider _dataAccessProvider;
    private readonly IRepositoryFactory _repositoryFactory;
    private readonly IEnumerable<IBeforeCommitHandler> _beforeCommitHandlers;

    public UnitOfWork(
        IDataAccessProvider dataAccessProvider,
        IRepositoryFactory repositoryFactory,
        IEnumerable<IBeforeCommitHandler> beforeCommitHandlers)
    {
        _dataAccessProvider = dataAccessProvider;
        _repositoryFactory = repositoryFactory;
        _beforeCommitHandlers = beforeCommitHandlers;
    }

    public async Task<int> Commit()
    {
        await _beforeCommitHandlers.ForEachOneByOneAsync(h => h.OnBeforeCommitAsync(this, _dataAccessProvider));

        return await _dataAccessProvider.Commit();
    }

    public IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class
    {
        return _repositoryFactory.GetGenericRepository<TEntity>();
    }

    public Task<SearchResult<TEntity>> Search<TEntity>(
        Query<TEntity> query,
        CancellationToken cancellationToken = default)
        where TEntity : class
    {
        return GetRepository<TEntity>().Search(query, cancellationToken);
    }

    public Task<SearchResult<TResult>> Search<TEntity, TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellationToken = default)
        where TEntity : class
    {
        return GetRepository<TEntity>().Search(query, selector, cancellationToken);
    }

    public Task<IReadOnlyCollection<TEntity>> GetCollection<TEntity>(
        Query<TEntity> query,
        CancellationToken cancellationToken = default)
        where TEntity : class
    {
        return GetRepository<TEntity>().GetCollection(query, cancellationToken);
    }

    public Task<IReadOnlyCollection<TResult>> GetCollection<TResult, TEntity>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellationToken = default) where TEntity : class
    {
        return GetRepository<TEntity>().GetCollection(query, selector, cancellationToken);
    }

    public Task<IReadOnlyCollection<TType>> Distinct<TEntity, TType>(
        Query<TEntity> query,
        Expression<Func<TEntity, TType>> selector)
        where TEntity : class
    {
        return GetRepository<TEntity>().Distinct(query, selector);
    }

    public Task<TEntity> GetFirst<TEntity>(Query<TEntity> query)
        where TEntity : class
    {
        return GetRepository<TEntity>().GetFirst(query);
    }

    public Task<TResult> GetFirst<TEntity, TResult>(Query<TEntity> query, Expression<Func<TEntity, TResult>> convertor)
        where TEntity : class
    {
        return GetRepository<TEntity>().GetFirst(query, convertor);
    }

    public Task<TEntity> GetFirstOrDefault<TEntity>(Query<TEntity> query)
        where TEntity : class
    {
        return GetRepository<TEntity>().GetFirstOrDefault(query);
    }

    public Task<TResult> GetFirstOrDefault<TEntity, TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> convertor)
        where TEntity : class
    {
        return GetRepository<TEntity>().GetFirstOrDefault(query, convertor);
    }

    public Task<TEntity> GetSingle<TEntity>(Query<TEntity> query)
        where TEntity : class
    {
        return GetRepository<TEntity>().GetSingle(query);
    }

    public Task<TResult> GetSingle<TEntity, TResult>(Query<TEntity> query, Expression<Func<TEntity, TResult>> convertor)
        where TEntity : class
    {
        return GetRepository<TEntity>().GetSingle(query, convertor);
    }

    public Task<TEntity> GetSingleOrDefault<TEntity>(Query<TEntity> query)
        where TEntity : class
    {
        return GetRepository<TEntity>().GetSingleOrDefault(query);
    }

    public Task<TResult> GetSingleOrDefault<TEntity, TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> convertor)
        where TEntity : class
    {
        return GetRepository<TEntity>().GetSingleOrDefault(query, convertor);
    }

    public Task<bool> Any<TEntity>(Query<TEntity> query)
        where TEntity : class
    {
        return GetRepository<TEntity>().Any(query);
    }

    public Task<int> Count<TEntity>(Query<TEntity> query)
        where TEntity : class
    {
        return GetRepository<TEntity>().Count(query);
    }

    public Task<int> Sum<TEntity>(Query<TEntity> query, Expression<Func<TEntity, int>> selector)
        where TEntity : class
    {
        return GetRepository<TEntity>().Sum(query, selector);
    }

    public Task<TEntity> AddOrUpdate<TEntity>(TEntity entity)
        where TEntity : class, IBaseEntity
    {
        var repo = GetRepository<TEntity>();

        return entity.IsNew ? repo.Add(entity) : repo.Update(entity);
    }

    public Task<TEntity> Add<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class, IBaseEntity
    {
        return GetRepository<TEntity>().Add(entity, cancellationToken);
    }

    public Task AddRange<TEntity>(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default)
        where TEntity : class, IBaseEntity
    {
        return GetRepository<TEntity>().AddRange(entities, cancellationToken);
    }

    public Task<TEntity> Update<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class, IBaseEntity
    {
        return GetRepository<TEntity>().Update(entity, cancellationToken);
    }

    public Task UpdateRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class, IBaseEntity
    {
        return GetRepository<TEntity>().UpdateRange(entities);
    }

    public Task Delete<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class, IBaseEntity
    {
        return GetRepository<TEntity>().Delete(entity, cancellationToken);
    }

    public Task DeleteRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class, IBaseEntity
    {
        return GetRepository<TEntity>().DeleteRange(entities);
    }
}