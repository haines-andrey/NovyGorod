using System.Linq.Expressions;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Domain.EntityAccess;

public interface IRepository<TEntity>
    where TEntity : class
{
    Task<SearchResult<TEntity>> Search(
        Query<TEntity> query,
        CancellationToken cancellationToken = default);

    Task<SearchResult<TResult>> Search<TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TEntity>> GetCollection(
        Query<TEntity> query,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TResult>> Distinct<TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector);

    Task<IReadOnlyCollection<TResult>> GetCollection<TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellationToken = default);

    Task<TEntity> GetFirstOrDefault(Query<TEntity> query);

    Task<TResult> GetFirstOrDefault<TResult>(Query<TEntity> query, Expression<Func<TEntity, TResult>> convertor);

    Task<TEntity> GetSingle(Query<TEntity> query);

    Task<TResult> GetSingle<TResult>(Query<TEntity> query, Expression<Func<TEntity, TResult>> convertor);

    Task<TEntity> GetSingleOrDefault(Query<TEntity> query);

    Task<TResult> GetSingleOrDefault<TResult>(Query<TEntity> query, Expression<Func<TEntity, TResult>> convertor);

    Task<bool> Any(Query<TEntity> query);

    Task<int> Count(Query<TEntity> query);

    Task<int> Sum(Query<TEntity> query, Expression<Func<TEntity, int>> selector);

    Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default);

    Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default);

    Task UpdateRange(IEnumerable<TEntity> entities);

    Task Delete(TEntity entity, CancellationToken cancellationToken = default);

    Task DeleteRange(IEnumerable<TEntity> entities);
}