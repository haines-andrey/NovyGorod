using System.Linq.Expressions;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Domain.EntityAccess;

public interface IEntityAccessService<TEntity>
{
    Task<SearchResult<TData>> GetAll<TData>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TData>> selector);

    Task<SearchResult<TEntity>> GetAll(IQueryParameters<TEntity> queryParameters);

    Task<IList<TEntity>> GetCollection(IQueryParameters<TEntity> queryParameters);

    Task<TData> GetSingleOrDefault<TData>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TData>> selector);

    Task<TEntity> GetSingleOrDefault(IQueryParameters<TEntity> queryParameters);

    Task<TResult> GetFirstOrDefault<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> convertor);

    Task<TEntity> GetFirstOrDefault(IQueryParameters<TEntity> queryParameters);

    Task<int> Sum(IQueryParameters<TEntity> queryParameters, Expression<Func<TEntity, int>> selector);

    Task<bool> Any(IQueryParameters<TEntity> queryParameters);

    Task<int> Count(IQueryParameters<TEntity> queryParameters);
}