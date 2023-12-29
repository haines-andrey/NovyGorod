using System;
using System.Linq;
using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries.Orderable;

namespace NovyGorod.Infrastructure.DataAccess.EF.Queries.Order;

internal class ThenOrderableQueryableAdapter<T> : IThenOrderable<T>, IQueryableConvertible<T>
{
    private readonly IOrderedQueryable<T> _queryable;

    public ThenOrderableQueryableAdapter(IOrderedQueryable<T> queryable)
    {
        _queryable = queryable;
    }

    public IQueryable<T> ToQueryable()
    {
        return _queryable;
    }

    public IThenOrderable<T> ThenBy<TKey>(Expression<Func<T, TKey>> keySelector)
    {
        return new ThenOrderableQueryableAdapter<T>(_queryable.ThenBy(keySelector));
    }

    public IThenOrderable<T> ThenByDesc<TKey>(Expression<Func<T, TKey>> keySelector)
    {
        return new ThenOrderableQueryableAdapter<T>(_queryable.ThenByDescending(keySelector));
    }
}