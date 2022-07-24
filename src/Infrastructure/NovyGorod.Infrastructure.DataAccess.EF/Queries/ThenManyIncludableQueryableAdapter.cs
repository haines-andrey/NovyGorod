using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NovyGorod.Domain.EntityAccess.Queries.Includes;

namespace NovyGorod.Infrastructure.DataAccess.EF.Queries;

internal class ThenManyIncludableQueryableAdapter<TParent, TProp>
    : IThenIncludable<TParent, TProp>
    where TParent : class
    where TProp : class
{
    private readonly IIncludableQueryable<TParent, IEnumerable<TProp>> _queryable;
    
    public ThenManyIncludableQueryableAdapter(IIncludableQueryable<TParent, IEnumerable<TProp>> queryable)
    {
        _queryable = queryable;
    }

    public IThenIncludable<TParent, TNextProp> ThenInclude<TNextProp>(Expression<Func<TProp, TNextProp>> accessor)
        where TNextProp : class
    {
        return new ThenIncludableQueryableAdapter<TParent, TNextProp>(_queryable.ThenInclude(accessor));
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
        return new ThenIncludableQueryableAdapter<TParent, TNewProp>(_queryable.Include(accessor));
    }

    public IThenIncludable<TParent, TNewProp> IncludeMany<TNewProp>(
        Expression<Func<TParent, IEnumerable<TNewProp>>> accessor)
        where TNewProp : class
    {
        return new ThenManyIncludableQueryableAdapter<TParent, TNewProp>(_queryable.Include(accessor));
    }

    public IQueryable<TParent> ToQueryable()
    {
        return _queryable;
    }
}