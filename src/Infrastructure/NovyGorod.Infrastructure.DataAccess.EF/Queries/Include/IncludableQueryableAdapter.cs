using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Domain.ModelAccess.Queries.Includable;

namespace NovyGorod.Infrastructure.DataAccess.EF.Queries.Include;

internal class IncludableQueryableAdapter<T> : IIncludable<T>, IQueryableConvertible<T>
    where T : class
{
    protected readonly IQueryable<T> _queryable;
    
    public IncludableQueryableAdapter(IQueryable<T> queryable)
    {
        _queryable = queryable;
    }

    public IQueryable<T> ToQueryable()
    {
        return _queryable;
    }

    public IThenIncludable<T, TProp> Include<TProp>(Expression<Func<T, TProp>> selector)
        where TProp : class
    {
        return new ThenIncludableQueryableAdapter<T, TProp>(
            _queryable.Include(selector));
    }

    public IThenIncludable<T, TProp> IncludeMany<TProp>(Expression<Func<T, IEnumerable<TProp>>> selector)
        where TProp : class
    {
        return new ThenManyIncludableQueryableAdapter<T, TProp>(
            _queryable.Include(selector));
    }
}