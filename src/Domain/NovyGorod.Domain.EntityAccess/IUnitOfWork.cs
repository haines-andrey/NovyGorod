using System.Linq.Expressions;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Results;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Domain.EntityAccess;

public interface IUnitOfWork : ICommitter
{
    IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class;

    Task<SearchResult<TEntity>> Search<TEntity>(Query<TEntity> query, CancellationToken cancellationToken = default)
        where TEntity : class;

    Task<SearchResult<TResult>> Search<TEntity, TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellationToken = default)
        where TEntity : class;

    Task<IReadOnlyCollection<TEntity>> GetCollection<TEntity>(
        Query<TEntity> query,
        CancellationToken cancellationToken = default)
        where TEntity : class;

    Task<IReadOnlyCollection<TResult>> GetCollection<TResult, TEntity>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellationToken = default)
        where TEntity : class;

    Task<IReadOnlyCollection<TResult>> Distinct<TEntity, TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector)
        where TEntity : class;

    Task<TEntity> GetFirstOrDefault<TEntity>(Query<TEntity> query)
        where TEntity : class;

    Task<TResult> GetFirstOrDefault<TEntity, TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> convertor)
        where TEntity : class;

    Task<TEntity> GetSingle<TEntity>(Query<TEntity> query)
        where TEntity : class;

    Task<TResult> GetSingle<TEntity, TResult>(Query<TEntity> query, Expression<Func<TEntity, TResult>> convertor)
        where TEntity : class;

    Task<TEntity> GetSingleOrDefault<TEntity>(Query<TEntity> query)
        where TEntity : class;

    Task<TResult> GetSingleOrDefault<TEntity, TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> convertor)
        where TEntity : class;

    Task<bool> Any<TEntity>(Query<TEntity> query)
        where TEntity : class;

    Task<int> Count<TEntity>(Query<TEntity> query)
        where TEntity : class;

    Task<int> Sum<TEntity>(Query<TEntity> query, Expression<Func<TEntity, int>> selector)
        where TEntity : class;

    Task<TEntity> Add<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class, IBaseEntity;

    Task AddRange<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        where TEntity : class, IBaseEntity;

    Task<TEntity> Update<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class, IBaseEntity;

    Task UpdateRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class, IBaseEntity;

    Task Delete<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class, IBaseEntity;

    Task DeleteRange<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class, IBaseEntity;
}