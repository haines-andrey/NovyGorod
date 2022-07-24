using System.Linq.Expressions;
using NovyGorod.Domain.EntityAccess.Queries.Includes;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Domain.EntityAccess.Queries.Builders;

/// <summary>
///     Builder for query object.
/// </summary>
/// <typeparam name="T">Type of requested data.</typeparam>
internal interface IQueryBuilder<T>
{
    /// <summary>
    ///     Specifies where clause merging with existing clause separated with Expression.AndAlso.
    /// </summary>
    /// <param name="predicate">Filtering expression.</param>
    /// <returns>Builder with applied where clause.</returns>
    IQueryBuilder<T> AndWhere(Expression<Func<T, bool>> predicate);

    /// <summary>
    ///     Specifies where clause merging with existing clause separated with Expression.Or.
    /// </summary>
    /// <param name="predicate">Filtering expression.</param>
    /// <returns>Builder with applied where clause.</returns>
    IQueryBuilder<T> OrWhere(Expression<Func<T, bool>> predicate);

    /// <summary>
    ///     Specifies ordering for result.
    /// </summary>
    /// <param name="ordering">Ordering expression.</param>
    /// <returns>Builder with applied ordering.</returns>
    IQueryBuilder<T> Ordering(Func<IQueryable<T>, IQueryable<T>> ordering);

    /// <summary>
    ///     Specifies ordering for result.
    /// </summary>
    /// <param name="orderType">Type of order.</param>
    /// <param name="keySelector">Selector of key to order.</param>
    /// <typeparam name="TKey">Type of ordering column.</typeparam>
    /// <returns>Builder with applied ordering.</returns>
    IQueryBuilder<T> Ordering<TKey>(
        OrderType orderType,
        Expression<Func<T, TKey>> keySelector);

    /// <summary>
    ///     Specifies ordering with subsequent (then by) selector for result.
    /// </summary>
    /// <param name="orderType">Type of order.</param>
    /// <param name="keySelector">Selector of key to order.</param>
    /// <param name="thenBySelector">Subsequent (then by) ordering selector of key to order.</param>
    /// <typeparam name="TKey1">Type of initial ordering column.</typeparam>
    /// <typeparam name="TKey2">Type of subsequent (then by) ordering column.</typeparam>
    /// <returns>Builder with applied ordering.</returns>
    IQueryBuilder<T> Ordering<TKey1, TKey2>(
        OrderType orderType,
        Expression<Func<T, TKey1>> keySelector,
        Expression<Func<T, TKey2>> thenBySelector);

    /// <summary>
    ///     Specifies eager include.
    /// </summary>
    /// <param name="include">IncludeMany specifying function.</param>
    /// <returns>Builder for chaining.</returns>
    IQueryBuilder<T> Include(Func<IIncludable<T>, IIncludable<T>> include);

    /// <summary>
    ///     Specifies paging.
    /// </summary>
    /// <param name="skip">Count of entities to skip.</param>
    /// <param name="take">Count of entities to take.</param>
    /// <returns>Builder with applied paging.</returns>
    IQueryBuilder<T> Paging(int skip, int take);

    /// <summary>
    ///     Specifies paging.
    /// </summary>
    /// <param name="paging">Query paging definition.</param>
    /// <returns>Builder with applied paging.</returns>
    IQueryBuilder<T> Paging(Paging paging);

    /// <summary>
    ///     Should be data requested with read only intent.
    /// </summary>
    /// <param name="isReadOnlyIntent">Specifies query with read only intention.</param>
    /// <returns>Builder with applied read only intention.</returns>
    IQueryBuilder<T> AsReadOnly(bool isReadOnlyIntent);

    /// <summary>
    ///     Adds query's excluded filters.
    /// </summary>
    /// <param name="excludedFilters">Specifies query with excluded filters.</param>
    /// <returns>Builder with applied excluded filters.</returns>
    IQueryBuilder<T> AddExcludedFilters(params string[] excludedFilters);

    /// <summary>
    ///     Constructs query object.
    /// </summary>
    /// <returns>Constructed <see cref="Query{T}"/> object.</returns>
    Query<T> ToQuery();
}