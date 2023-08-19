using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.ModelAccess.Queries.Results;
using NovyGorod.Infrastructure.DataAccess.EF.Queries;
using NovyGorod.Infrastructure.DataAccess.EF.Queries.Include;
using NovyGorod.Infrastructure.DataAccess.EF.Queries.Order;

namespace NovyGorod.Infrastructure.DataAccess.EF.Repositories;

internal static class QueryExtensions
{
    public static IQueryable<TEntity> ToQueryable<TEntity>(
        this IQuery<TEntity> query,
        IQueryable<TEntity> source,
        bool includePaging = true)
        where TEntity : class
    {
        if (query.Filter is not null)
        {
            source = source.Where(query.Filter.Expression);
        }

        if (query.Orderable is not null)
        {
            var orderedAdapter = new OrderableQueryableAdapter<TEntity>(source);
            var ordered = query.Orderable.Compile().Invoke(orderedAdapter);
            source = ((IQueryableConvertible<TEntity>)ordered).ToQueryable();
        }

        if (query.Includable is not null)
        {
            var includableAdapter = new IncludableQueryableAdapter<TEntity>(source);
            var includable = query.Includable.Compile().Invoke(includableAdapter);
            source = ((IQueryableConvertible<TEntity>)includable).ToQueryable();
        }

        if (includePaging && query.Skip > 0)
        {
            source = source.Skip(query.Skip);
        }

        if (includePaging && query.Take > 0)
        {
            source = source.Take(query.Take);
        }

        if (query.IsReadOnly)
        {
            source = source.AsNoTracking();
        }

        return source;
    }

    public static async Task<Pagination<TData>> ToPagination<TEntity, TData>(
        this IQuery<TEntity> query,
        IQueryable<TEntity> entitySet,
        Expression<Func<TEntity, TData>> dataSelector,
        CancellationToken cancellationToken)
        where TEntity : class
    {
        var total = await query.ToQueryable(entitySet, includePaging: false).CountAsync(cancellationToken);
        var items = await query.ToQueryable(entitySet).Select(dataSelector).ToListAsync(cancellationToken);
        var paging = new Paging {Total = total, Skip = query.Skip, PageSize = query.Take};

        return new Pagination<TData> {Paging = paging, Items = items};
    }
}