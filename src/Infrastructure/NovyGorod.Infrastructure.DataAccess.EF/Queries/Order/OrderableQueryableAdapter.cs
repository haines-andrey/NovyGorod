using System;
using System.Linq;
using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries.Orderable;

namespace NovyGorod.Infrastructure.DataAccess.EF.Queries.Order;

internal class OrderableQueryableAdapter<T> : IOrderable<T>, IQueryableConvertible<T>
    where T : class
{
    private readonly IQueryable<T> _queryable;

    public OrderableQueryableAdapter(IQueryable<T> queryable)
    {
        _queryable = queryable;
    }

    public IQueryable<T> ToQueryable()
    {
        return _queryable;
    }

    public IThenOrderable<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector)
    {
        return new ThenOrderableQueryableAdapter<T>(_queryable.OrderBy(keySelector));
    }

    public IThenOrderable<T> OrderByDesc<TKey>(Expression<Func<T, TKey>> keySelector)
    {
        return new ThenOrderableQueryableAdapter<T>(_queryable.OrderByDescending(keySelector));
    }
}