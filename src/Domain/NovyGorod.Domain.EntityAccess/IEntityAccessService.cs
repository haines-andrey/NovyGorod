using System.Linq.Expressions;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Domain.EntityAccess;

public interface IEntityAccessService<TEntity>
{
    Task<SearchResult<TEntity>> Search(IQueryParameters<TEntity> queryParameters);

    Task<SearchResult<TData>> Search<TData>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TData>> selector);

    Task<IReadOnlyCollection<TEntity>> GetCollection(IQueryParameters<TEntity> queryParameters);

    Task<IReadOnlyCollection<TResult>> GetCollection<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> selector);
    
    Task<IReadOnlyCollection<TResult>> Distinct<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> selector);

    Task<TData> GetSingleOrDefault<TData>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TData>> selector);

    Task<TEntity> GetSingleOrDefault(IQueryParameters<TEntity> queryParameters);

    Task<TResult> GetFirstOrDefault<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> convertor);

    Task<TEntity> GetFirstOrDefault(IQueryParameters<TEntity> queryParameters);

    Task<TData> GetSingle<TData>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TData>> selector);

    Task<TEntity> GetSingle(IQueryParameters<TEntity> queryParameters);

    Task<TResult> GetFirst<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> convertor);

    Task<TEntity> GetFirst(IQueryParameters<TEntity> queryParameters);

    Task<int> Sum(IQueryParameters<TEntity> queryParameters, Expression<Func<TEntity, int>> selector);

    Task<bool> Any(IQueryParameters<TEntity> queryParameters);

    Task<int> Count(IQueryParameters<TEntity> queryParameters);
}