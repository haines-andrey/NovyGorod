using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Common.Exceptions;
using NovyGorod.Common.Utils;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries;
using NovyGorod.Domain.ModelAccess.Queries.Results;

namespace NovyGorod.Infrastructure.DataAccess.EF.Repositories;

public class EfReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
    where TEntity : class
{
    protected readonly DbContext DbContext;

    public EfReadOnlyRepository(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    protected virtual IQueryable<TEntity> GetQueryable() => DbContext.Set<TEntity>();

    public async Task<TEntity> GetById(
        Func<object[]> idValueSelector,
        CancellationToken cancellationToken = default)
    {
        var id = idValueSelector();
        var entity = await DbContext.FindAsync<TEntity>(id, cancellationToken);
        
        Contract.IsNotNull<CodedException>(entity, ErrorCode.EntityNotFound);

        return entity;
    }

    public async Task<IReadOnlyCollection<TEntity>> GetCollectionByIds(
        Func<IEnumerable<object[]>> idValuesSelector,
        CancellationToken cancellationToken = default)
    {
        var ids = idValuesSelector();
        var list = new List<TEntity>();

        foreach (var id in ids)
        {
            var entity = await GetById(() => id, cancellationToken);
            list.Add(entity);
        }

        return list;
    }

    public Task<Pagination<TEntity>> Paginate(
        IQuery<TEntity> query,
        CancellationToken cancellationToken = default)
    {
        return query.ToPagination(GetQueryable(), entity => entity, cancellationToken);
    }

    public Task<Pagination<TData>> Paginate<TData>(
        IQuery<TEntity> query,
        Expression<Func<TEntity, TData>> dataSelector,
        CancellationToken cancellationToken = default)
    {
        return query.ToPagination(GetQueryable(), dataSelector, cancellationToken);
    }

    public async Task<IReadOnlyCollection<TEntity>> GetCollection(
        IQuery<TEntity> query,
        CancellationToken cancellationToken = default)
    {
        return await query.ToQueryable(GetQueryable()).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<TData>> GetCollection<TData>(
        IQuery<TEntity> query,
        Expression<Func<TEntity, TData>> dataSelector,
        CancellationToken cancellationToken = default)
    {
        return await query.ToQueryable(GetQueryable()).Select(dataSelector).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<TData>> Distinct<TData>(
        IQuery<TEntity> query,
        Expression<Func<TEntity, TData>> dataSelector,
        CancellationToken cancellationToken = default)
    {
        return await query.ToQueryable(GetQueryable()).Select(dataSelector).Distinct().ToListAsync(cancellationToken);
    }

    public async Task<TEntity> GetFirst(
        IQuery<TEntity> query,
        CancellationToken cancellationToken = default)
    {
        var entity = await query.ToQueryable(GetQueryable()).FirstOrDefaultAsync(cancellationToken);

        Contract.IsNotNull<CodedException>(entity, ErrorCode.EntityNotFound);

        return entity;
    }

    public async Task<TData> GetFirst<TData>(
        IQuery<TEntity> query,
        Expression<Func<TEntity, TData>> dataSelector,
        CancellationToken cancellationToken = default)
    {
        var entity = await query.ToQueryable(GetQueryable()).Select(dataSelector)
            .FirstOrDefaultAsync(cancellationToken);

        Contract.IsNotNull<CodedException>(entity, ErrorCode.EntityNotFound);

        return entity;
    }

    public Task<TEntity> GetFirstOrDefault(
        IQuery<TEntity> query,
        CancellationToken cancellationToken = default)
    {
        return query.ToQueryable(GetQueryable()).FirstOrDefaultAsync(cancellationToken);
    }

    public Task<TData> GetFirstOrDefault<TData>(
        IQuery<TEntity> query,
        Expression<Func<TEntity, TData>> dataSelector,
        CancellationToken cancellationToken = default)
    {
        return query.ToQueryable(GetQueryable()).Select(dataSelector).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity> GetSingle(
        IQuery<TEntity> query,
        CancellationToken cancellationToken = default)
    {
        var entity = await query.ToQueryable(GetQueryable()).SingleOrDefaultAsync(cancellationToken);

        Contract.IsNotNull<CodedException>(entity, ErrorCode.EntityNotFound);

        return entity;
    }

    public async Task<TData> GetSingle<TData>(
        IQuery<TEntity> query,
        Expression<Func<TEntity, TData>> dataSelector,
        CancellationToken cancellationToken = default)
    {
        var entity = await query.ToQueryable(GetQueryable()).Select(dataSelector)
            .SingleOrDefaultAsync(cancellationToken);

        Contract.IsNotNull<CodedException>(entity, ErrorCode.EntityNotFound);

        return entity;
    }

    public Task<TEntity> GetSingleOrDefault(
        IQuery<TEntity> query,
        CancellationToken cancellationToken = default)
    {
        return query.ToQueryable(GetQueryable()).SingleOrDefaultAsync(cancellationToken);
    }

    public Task<TData> GetSingleOrDefault<TData>(
        IQuery<TEntity> query,
        Expression<Func<TEntity, TData>> dataSelector,
        CancellationToken cancellationToken = default)
    {
        return query.ToQueryable(GetQueryable()).Select(dataSelector).SingleOrDefaultAsync(cancellationToken);
    }

    public Task<bool> Any(
        IQuery<TEntity> query,
        CancellationToken cancellationToken = default)
    {
        return query.ToQueryable(GetQueryable()).AnyAsync(cancellationToken);
    }

    public Task<int> Count(
        IQuery<TEntity> query,
        CancellationToken cancellationToken = default)
    {
        return query.ToQueryable(GetQueryable()).CountAsync(cancellationToken);
    }

    public Task<int> Sum(
        IQuery<TEntity> query,
        Expression<Func<TEntity, int>> dataSelector,
        CancellationToken cancellationToken = default)
    {
        return query.ToQueryable(GetQueryable()).SumAsync(dataSelector, cancellationToken);
    }
}