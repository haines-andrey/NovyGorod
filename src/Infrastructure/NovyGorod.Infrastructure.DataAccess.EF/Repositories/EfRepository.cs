using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Domain.ModelAccess;

namespace NovyGorod.Infrastructure.DataAccess.EF.Repositories;

public class EfRepository<TEntity> : EfReadOnlyRepository<TEntity>, IRepository<TEntity>
    where TEntity : class
{
    public EfRepository(DbContext dbContext)
        : base(dbContext)
    {
    }

    protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();

    public async Task<TEntity> Add(TEntity model, CancellationToken cancellationToken = default)
    {
        var result = await DbSet.AddAsync(model, cancellationToken);

        return result.Entity;
    }
    
    public Task Add(IEnumerable<TEntity> models, CancellationToken cancellationToken = default)
    {
        return DbSet.AddRangeAsync(models, cancellationToken);
    }
    
    public Task<TEntity> Update(TEntity model, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult(DbSet.Update(model).Entity);
    }

    public Task Update(IEnumerable<TEntity> models, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        DbSet.UpdateRange(models);

        return Task.CompletedTask;
    }

    public Task Delete(TEntity model, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        DbSet.Remove(model);

        return Task.CompletedTask;
    }

    public Task Delete(IEnumerable<TEntity> models, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        DbSet.RemoveRange(models);

        return Task.CompletedTask;
    }
}