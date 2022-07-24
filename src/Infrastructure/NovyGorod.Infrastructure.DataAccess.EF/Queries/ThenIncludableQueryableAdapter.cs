using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NovyGorod.Domain.EntityAccess.Queries.Includes;

namespace NovyGorod.Infrastructure.DataAccess.EF.Queries;

internal class ThenIncludableQueryableAdapter<TParent, TProp> : IThenIncludable<TParent, TProp>
    where TParent : class
    where TProp : class
{
    private readonly IIncludableQueryable<TParent, TProp> _queryable;
    
    public ThenIncludableQueryableAdapter(IIncludableQueryable<TParent, TProp> queryable)
    {
        _queryable = queryable;
    }

    public IThenIncludable<TParent, TNextProp> ThenInclude<TNextProp>(Expression<Func<TProp, TNextProp>> accessor)
        where TNextProp : class
    {
        var childIncludable = _queryable.ThenInclude(accessor);

        return new ThenIncludableQueryableAdapter<TParent, TNextProp>(childIncludable);
    }

    public IThenIncludable<TParent, TNextProp> ThenMany<TNextProp>(
        Expression<Func<TProp, IEnumerable<TNextProp>>> accessor)
        where TNextProp : class
    {
        return new ThenManyIncludableQueryableAdapter<TParent, TNextProp>(_queryable.ThenInclude(accessor));
    }

    public IThenIncludable<TParent, TNewProp> Include<TNewProp>(Expression<Func<TParent, TNewProp>> accessor)
        where TNewProp : class
    {
        var include = _queryable.Include(accessor);

        return new ThenIncludableQueryableAdapter<TParent, TNewProp>(include);
    }

    public IThenIncludable<TParent, TNextProp> IncludeMany<TNextProp>(
        Expression<Func<TParent, IEnumerable<TNextProp>>> accessor)
        where TNextProp : class
    {
        return new ThenManyIncludableQueryableAdapter<TParent, TNextProp>(_queryable.Include(accessor));
    }

    public IQueryable<TParent> ToQueryable()
    {
        return _queryable;
    }
}