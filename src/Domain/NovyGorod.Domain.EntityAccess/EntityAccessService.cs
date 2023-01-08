using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Domain.EntityAccess;

[ExcludeFromCodeCoverage]
internal class EntityAccessService<TEntity> : IEntityAccessService<TEntity>
    where TEntity : class
{
    private readonly IUnitOfWork _unitOfWork;

    public EntityAccessService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<SearchResult<TEntity>> Search(IQueryParameters<TEntity> queryParameters)
    {
        return _unitOfWork.Search(queryParameters.ToQuery());
    }

    public Task<SearchResult<TResult>> Search<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> selector)
    {
        return _unitOfWork.Search(queryParameters.ToQuery(), selector);
    }

    public Task<IReadOnlyCollection<TEntity>> GetCollection(IQueryParameters<TEntity> queryParameters)
    {
        return _unitOfWork.GetCollection(queryParameters.ToQuery());
    }

    public Task<IReadOnlyCollection<TResult>> GetCollection<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> selector)
    {
        return _unitOfWork.GetCollection(queryParameters.ToQuery(), selector);
    }

    public Task<IReadOnlyCollection<TResult>> Distinct<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> selector)
    {
        return _unitOfWork.Distinct(queryParameters.ToQuery(), selector);
    }

    public Task<TResult> GetSingleOrDefault<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> selector)
    {
        return _unitOfWork.GetSingleOrDefault(queryParameters.ToQuery(), selector);
    }

    public Task<TEntity> GetSingleOrDefault(IQueryParameters<TEntity> queryParameters)
    {
        return _unitOfWork.GetSingleOrDefault(queryParameters.ToQuery());
    }

    public Task<TResult> GetFirstOrDefault<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> convertor)
    {
        return _unitOfWork.GetFirstOrDefault(queryParameters.ToQuery(), convertor);
    }

    public Task<TEntity> GetFirstOrDefault(IQueryParameters<TEntity> queryParameters)
    {
        return _unitOfWork.GetFirstOrDefault(queryParameters.ToQuery());
    }

    public Task<TData> GetSingle<TData>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TData>> selector)
    {
        return _unitOfWork.GetSingle(queryParameters.ToQuery(), selector);
    }

    public Task<TEntity> GetSingle(IQueryParameters<TEntity> queryParameters)
    {
        return _unitOfWork.GetSingle(queryParameters.ToQuery());
    }

    public Task<TResult> GetFirst<TResult>(
        IQueryParameters<TEntity> queryParameters,
        Expression<Func<TEntity, TResult>> convertor)
    {
        return _unitOfWork.GetFirst(queryParameters.ToQuery(), convertor);
    }

    public Task<TEntity> GetFirst(IQueryParameters<TEntity> queryParameters)
    {
        return _unitOfWork.GetFirst(queryParameters.ToQuery());
    }

    public Task<int> Sum(IQueryParameters<TEntity> queryParameters, Expression<Func<TEntity, int>> selector)
    {
        return _unitOfWork.Sum(queryParameters.ToQuery(), selector);
    }

    public Task<bool> Any(IQueryParameters<TEntity> queryParameters)
    {
        return _unitOfWork.Any(queryParameters.ToQuery());
    }

    public Task<int> Count(IQueryParameters<TEntity> queryParameters)
    {
        return _unitOfWork.Count(queryParameters.ToQuery());
    }
}