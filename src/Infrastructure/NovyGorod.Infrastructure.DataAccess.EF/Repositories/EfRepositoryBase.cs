using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.EntityAccess.Queries.Results;
using NovyGorod.Infrastructure.DataAccess.EF.Queries;

namespace NovyGorod.Infrastructure.DataAccess.EF.Repositories;

public abstract class EfRepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected EfRepositoryBase(DbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    protected DbContext DbContext { get; }

    public async Task<SearchResult<TEntity>> Search(
        Query<TEntity> query,
        CancellationToken cancellationToken = default)
    {
        var totalCount = await CountWithoutPaging(query);

        return await Query(query).ToSearchResult(query.Paging, totalCount, cancellationToken);
    }

    public async Task<SearchResult<TResult>> Search<TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellationToken = default)
    {
        var totalCount = await CountWithoutPaging(query);

        return await Query(query).Select(selector).ToSearchResult(query.Paging, totalCount, cancellationToken);
    }

    public async Task<IReadOnlyCollection<TEntity>> GetCollection(
        Query<TEntity> query,
        CancellationToken cancellationToken = default)
    {
        var items = await Query(query).ToListAsync(cancellationToken);

        return items;
    }

    public async Task<IReadOnlyCollection<TResult>> GetCollection<TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellationToken = default)
    {
        var items = await Query(query).Select(selector).ToListAsync(cancellationToken);

        return items;
    }

    public async Task<IReadOnlyCollection<TResult>> Distinct<TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> selector)
    {
        var items = await Query(query).Select(selector).Distinct().ToListAsync();

        return items;
    }

    public Task<TEntity> GetFirstOrDefault(Query<TEntity> query)
    {
        return Query(query).FirstOrDefaultAsync();
    }

    public Task<TResult> GetFirstOrDefault<TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> convertor)
    {
        return Query(query).Select(convertor).FirstOrDefaultAsync();
    }

    public Task<TEntity> GetSingle(Query<TEntity> query)
    {
        return Query(query).SingleAsync();
    }

    public Task<TResult> GetSingle<TResult>(Query<TEntity> query, Expression<Func<TEntity, TResult>> convertor)
    {
        return Query(query).Select(convertor).SingleAsync();
    }

    public Task<TEntity> GetSingleOrDefault(Query<TEntity> query)
    {
        return Query(query).SingleOrDefaultAsync();
    }

    public Task<TResult> GetSingleOrDefault<TResult>(
        Query<TEntity> query,
        Expression<Func<TEntity, TResult>> convertor)
    {
        return Query(query).Select(convertor).SingleOrDefaultAsync();
    }

    public Task<bool> Any(Query<TEntity> query)
    {
        return Query(query).AnyAsync();
    }

    public Task<int> Count(Query<TEntity> query)
    {
        return Query(query).CountAsync();
    }

    public Task<int> Sum(Query<TEntity> query, Expression<Func<TEntity, int>> selector)
    {
        return Query(query).Select(selector).SumAsync();
    }

    public abstract Task<TEntity> Add(
        TEntity entity,
        CancellationToken cancellationToken = default);

    public abstract Task AddRange(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default);

    public abstract Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default);

    public abstract Task UpdateRange(IEnumerable<TEntity> entities);

    public abstract Task Delete(TEntity entity, CancellationToken cancellationToken = default);

    public abstract Task DeleteRange(IEnumerable<TEntity> entities);

    protected abstract IQueryable<TEntity> GetQueryable();

    protected virtual IQueryable<TEntity> Query(Query<TEntity> query)
    {
        var queryable = GetQueryable();
        if (query.Include != null)
        {
            queryable = query.Include(new IncludableQueryableAdapter<TEntity>(queryable)).ToQueryable();
        }

        if (query.ReadOnly)
        {
            queryable = queryable.AsNoTracking();
        }

        if (query.Where != null)
        {
            queryable = queryable.Where(query.Where);
        }

        if (query.Ordering != null)
        {
            queryable = query.Ordering(queryable);
        }

        if (query.Paging != null)
        {
            queryable = queryable.Skip(query.Paging.Skip).Take(query.Paging.Take);
        }

        return queryable;
    }

    protected async Task<int> CountWithoutPaging(Query<TEntity> query)
    {
        var paging = query.Paging;
        query.Paging = null;
        var totalCount = await Query(query).CountAsync();
        query.Paging = paging;

        return totalCount;
    }
}