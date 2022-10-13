using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Infrastructure.DataAccess.EF.Queries;

public static class QueryableSearchResultExtensions
{
    public static async Task<SearchResult<TEntity>> ToSearchResult<TEntity>(
        this IQueryable<TEntity> source,
        Paging paging,
        int totalCount,
        CancellationToken cancellationToken = default)
    {
        var items = await source.ToListAsync(cancellationToken);

        return CreateSearchResult(items, totalCount, paging);
    }

    private static SearchResult<T> CreateSearchResult<T>(IReadOnlyCollection<T> items, int total, Paging paging)
    {
        return new SearchResult<T>
        {
            Paging = paging != null ? new PagingResult(paging.Skip, paging.Take, total) : null,
            Items = items,
        };
    }
}