using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NovyGorod.Domain.ModelAccess.Queries.Includable;

namespace NovyGorod.Infrastructure.DataAccess.EF.Queries.Include;

internal class ThenManyIncludableQueryableAdapter<T, TProp> : IThenIncludable<T, TProp>, IQueryableConvertible<T>
    where T : class
    where TProp : class
{
    private readonly IIncludableQueryable<T, IEnumerable<TProp>> _queryable;

    public ThenManyIncludableQueryableAdapter(IIncludableQueryable<T, IEnumerable<TProp>> queryable)
    {
        _queryable = queryable;
    }

    public IQueryable<T> ToQueryable()
    {
        return _queryable;
    }

    public IThenIncludable<T, TNextProp> Include<TNextProp>(Expression<Func<T, TNextProp>> selector)
        where TNextProp : class
    {
        return new ThenIncludableQueryableAdapter<T, TNextProp>(
            _queryable.Include(selector));
    }

    public IThenIncludable<T, TNextProp> IncludeMany<TNextProp>(
        Expression<Func<T, IEnumerable<TNextProp>>> selector)
        where TNextProp : class
    {
        return new ThenManyIncludableQueryableAdapter<T, TNextProp>(
            _queryable.Include(selector));
    }

    public IThenIncludable<T, TNextProp> Then<TNextProp>(Expression<Func<TProp, TNextProp>> selector)
        where TNextProp : class
    {
        return new ThenIncludableQueryableAdapter<T, TNextProp>(
            _queryable.ThenInclude(selector));
    }

    public IThenIncludable<T, TNextProp> ThenMany<TNextProp>(
        Expression<Func<TProp, IEnumerable<TNextProp>>> selector)
        where TNextProp : class
    {
        return new ThenManyIncludableQueryableAdapter<T, TNextProp>(
            _queryable.ThenInclude(selector));
    }
}