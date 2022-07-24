using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NovyGorod.Infrastructure.DataAccess.EF.Repositories;

public class EfRepository<TEntity> : EfRepositoryBase<TEntity>
    where TEntity : class
{
    public EfRepository(DbContext dbContext)
        : base(dbContext)
    {
        DbSet = DbContext.Set<TEntity>();
    }
    
    protected DbSet<TEntity> DbSet { get; set; }
    
    public override async Task<TEntity> Add(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        var result = await DbSet.AddAsync(entity, cancellationToken);

        return result.Entity;
    }
    
    public override Task AddRange(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default)
    {
        return DbSet.AddRangeAsync(entities, cancellationToken);
    }
    
    public override Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult(DbSet.Update(entity).Entity);
    }
    
    public override Task UpdateRange(IEnumerable<TEntity> entities)
    {
        DbSet.UpdateRange(entities);

        return Task.CompletedTask;
    }
    
    public override Task Delete(TEntity entity, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        DbSet.Remove(entity);

        return Task.CompletedTask;
    }
    
    public override Task DeleteRange(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);

        return Task.CompletedTask;
    }

    protected override IQueryable<TEntity> GetQueryable()
    {
        return DbSet.AsQueryable();
    }
}