using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Domain.EntityAccess.Queries.Includes;

namespace NovyGorod.Infrastructure.DataAccess.EF.Queries;

internal class IncludableQueryableAdapter<T> : IIncludable<T>
    where T : class
{
    private readonly IQueryable<T> _queryable;
    
    public IncludableQueryableAdapter(IQueryable<T> queryable)
    {
        _queryable = queryable;
    }

    public IThenIncludable<T, TProp> Include<TProp>(Expression<Func<T, TProp>> accessor)
        where TProp : class
    {
        var includable = _queryable.Include(accessor);

        return new ThenIncludableQueryableAdapter<T, TProp>(includable);
    }

    public IThenIncludable<T, TProp> IncludeMany<TProp>(Expression<Func<T, IEnumerable<TProp>>> accessor)
        where TProp : class
    {
        return new ThenManyIncludableQueryableAdapter<T, TProp>(_queryable.Include(accessor));
    }

    public IQueryable<T> ToQueryable()
    {
        return _queryable;
    }
}