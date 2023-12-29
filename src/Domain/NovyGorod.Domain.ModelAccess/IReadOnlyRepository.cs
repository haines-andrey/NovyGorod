using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.ModelAccess.Queries.Results;

namespace NovyGorod.Domain.ModelAccess;

public interface IReadOnlyRepository<TModel>
    where TModel : class
{
    Task<Pagination<TModel>> Paginate(
        IQuery<TModel> query,
        CancellationToken cancellationToken = default);

    Task<Pagination<TData>> Paginate<TData>(
        IQuery<TModel> query,
        Expression<Func<TModel, TData>> dataSelector,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TModel>> GetCollection(
        IQuery<TModel> query,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TData>> GetCollection<TData>(
        IQuery<TModel> query,
        Expression<Func<TModel, TData>> dataSelector,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<TData>> Distinct<TData>(
        IQuery<TModel> query,
        Expression<Func<TModel, TData>> dataSelector,
        CancellationToken cancellationToken = default);

    Task<TModel> GetFirst(
        IQuery<TModel> query,
        CancellationToken cancellationToken = default);

    Task<TData> GetFirst<TData>(
        IQuery<TModel> query,
        Expression<Func<TModel, TData>> dataSelector,
        CancellationToken cancellationToken = default);

    Task<TModel> GetFirstOrDefault(
        IQuery<TModel> query,
        CancellationToken cancellationToken = default);

    Task<TData> GetFirstOrDefault<TData>(
        IQuery<TModel> query,
        Expression<Func<TModel, TData>> dataSelector,
        CancellationToken cancellationToken = default);

    Task<TModel> GetSingle(
        IQuery<TModel> query,
        CancellationToken cancellationToken = default);

    Task<TData> GetSingle<TData>(
        IQuery<TModel> query,
        Expression<Func<TModel, TData>> dataSelector,
        CancellationToken cancellationToken = default);

    Task<TModel> GetSingleOrDefault(
        IQuery<TModel> query,
        CancellationToken cancellationToken = default);

    Task<TData> GetSingleOrDefault<TData>(
        IQuery<TModel> query,
        Expression<Func<TModel, TData>> dataSelector,
        CancellationToken cancellationToken = default);

    Task<bool> Any(
        IQuery<TModel> query,
        CancellationToken cancellationToken = default);

    Task<int> Count(
        IQuery<TModel> query,
        CancellationToken cancellationToken = default);

    Task<int> Sum(
        IQuery<TModel> query,
        Expression<Func<TModel, int>> dataSelector,
        CancellationToken cancellationToken = default);
}