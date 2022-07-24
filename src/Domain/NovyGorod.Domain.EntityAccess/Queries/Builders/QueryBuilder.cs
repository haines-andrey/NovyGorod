using System.Linq.Expressions;
using NovyGorod.Common.Utils.Expressions;
using NovyGorod.Domain.EntityAccess.Queries.Includes;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Domain.EntityAccess.Queries.Builders;

/// <inheritdoc />
internal class QueryBuilder<T> : IQueryBuilder<T>
{
    private readonly Query<T> _query = new();

    /// <inheritdoc />
    public IQueryBuilder<T> AndWhere(Expression<Func<T, bool>> predicate)
    {
        _query.Where = _query.Where != null ? ExpressionsUtils.AndAlso(_query.Where, predicate) : predicate;

        return this;
    }

    /// <inheritdoc />
    public IQueryBuilder<T> OrWhere(Expression<Func<T, bool>> predicate)
    {
        _query.Where = _query.Where != null ? ExpressionsUtils.Or(_query.Where, predicate) : predicate;

        return this;
    }

    /// <inheritdoc />
    public IQueryBuilder<T> Ordering(Func<IQueryable<T>, IQueryable<T>> ordering)
    {
        _query.Ordering = ordering;

        return this;
    }

    /// <inheritdoc />
    public IQueryBuilder<T> Ordering<TKey>(OrderType orderType, Expression<Func<T, TKey>> keySelector)
    {
        _query.Ordering = GetOrderingExpression(orderType, keySelector);

        return this;
    }

    /// <inheritdoc />
    public IQueryBuilder<T> Ordering<TKey1, TKey2>(
        OrderType orderType,
        Expression<Func<T, TKey1>> keySelector,
        Expression<Func<T, TKey2>> thenBySelector)
    {
        _query.Ordering = GetOrderingExpression(orderType, keySelector, thenBySelector);

        return this;
    }

    /// <inheritdoc />
    public IQueryBuilder<T> Include(Func<IIncludable<T>, IIncludable<T>> include)
    {
        _query.Include = include;

        return this;
    }

    /// <inheritdoc />
    public IQueryBuilder<T> Paging(int skip, int take)
    {
        _query.Paging = new Paging(skip, take);

        return this;
    }

    /// <inheritdoc />
    public IQueryBuilder<T> Paging(Paging paging)
    {
        _query.Paging = paging;

        return this;
    }

    /// <inheritdoc />
    public IQueryBuilder<T> AsReadOnly(bool isReadOnlyIntent)
    {
        _query.ReadOnly = isReadOnlyIntent;

        return this;
    }

    /// <inheritdoc />
    public IQueryBuilder<T> AddExcludedFilters(params string[] excludedFilters)
    {
        _query.ExcludedFilters = _query.ExcludedFilters != null
            ? _query.ExcludedFilters.Concat(excludedFilters)
            : excludedFilters;

        return this;
    }

    /// <inheritdoc />
    public Query<T> ToQuery()
    {
        return _query;
    }

    private static Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderingExpression<TKey>(
        OrderType orderType,
        Expression<Func<T, TKey>> keySelector)
    {
        if (orderType == OrderType.Desc)
        {
            return c => c.OrderByDescending(keySelector);
        }

        return c => c.OrderBy(keySelector);
    }

    private static Func<IQueryable<T>, IOrderedQueryable<T>> GetOrderingExpression<TKey1, TKey2>(
        OrderType orderType,
        Expression<Func<T, TKey1>> keySelector,
        Expression<Func<T, TKey2>> thenBySelector)
    {
        if (orderType == OrderType.Desc)
        {
            return c => c.OrderByDescending(keySelector).ThenByDescending(thenBySelector);
        }

        return c => c.OrderBy(keySelector).ThenBy(thenBySelector);
    }
}