using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Infrastructure.DataAccess.EF.Queries;

public static class QueryableSearchResultExtensions
{
    public static SearchResult<T> ToSearchResult<T>(
        this IQueryable<T> source,
        Paging paging)
    {
        return paging == null
            ? ToNonPagedSearchResultInternal(source)
            : ToPagedSearchResultInternal(source, paging);
    }
    
    public static async Task<SearchResult<T>> ToSearchResult<T>(
        this IQueryable<T> source,
        Paging paging,
        CancellationToken cancellationToken = default)
    {
        var result = await ExecuteQuery(source, paging, cancellationToken);

        return ToSearchResult(result.items, result.total, paging);
    }

    private static SearchResult<T> ToPagedSearchResultInternal<T>(IQueryable<T> source, Paging paging)
    {
        var result = source.ApplyPaging(paging).ToArray();
        var count = CalculateTotal(result, paging) ?? source.Count();

        return ToSearchResult(result, count, paging);
    }

    private static SearchResult<T> ToNonPagedSearchResultInternal<T>(IQueryable<T> source)
    {
        var result = source.ToArray();

        return ToSearchResult(result, result.Length, null);
    }

    private static SearchResult<T> ToSearchResult<T>(IReadOnlyCollection<T> items, int total, Paging paging)
    {
        return new SearchResult<T>
        {
            Paging = paging != null ? new PagingResult(paging.Skip, paging.Take, total) : null, Items = items,
        };
    }

    private static Task<(IReadOnlyCollection<T> items, int total)> ExecuteQuery<T>(
        IQueryable<T> source,
        Paging paging,
        CancellationToken token)
    {
        return paging != null
            ? ExecutePagedQuery(source, paging, token)
            : ExecuteQuery(source, token);
    }

    private static async Task<(IReadOnlyCollection<T> items, int total)> ExecutePagedQuery<T>(
        IQueryable<T> source, Paging paging, CancellationToken token)
    {
        var items = await source.ApplyPaging(paging)
            .ToListAsync(token);

        var count = CalculateTotal(items, paging) ?? await source.CountAsync(token);

        return (items, count);
    }

    private static IQueryable<T> ApplyPaging<T>(this IQueryable<T> queryable, Paging paging)
    {
        return queryable.Skip(paging.Skip).Take(paging.Take);
    }

    private static async Task<(IReadOnlyCollection<T> items, int total)> ExecuteQuery<T>(
        IQueryable<T> source,
        CancellationToken token)
    {
        var items = await source.ToListAsync(token);

        return (items, items.Count);
    }

    private static int? CalculateTotal<T>(IList<T> items, Paging paging)
    {
        return CanCalculateTotal(items, paging) ? items.Count + paging.Skip : default(int?);
    }

    private static bool CanCalculateTotal<T>(IList<T> result, Paging paging)
    {
        return result.Count < paging.Take && (result.Count > 0 || paging.Skip == 0);
    }
}