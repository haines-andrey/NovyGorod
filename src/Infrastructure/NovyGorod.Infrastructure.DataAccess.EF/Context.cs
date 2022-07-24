using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NovyGorod.Infrastructure.DataAccess.Core;
using NovyGorod.Infrastructure.ModelConfigs;

namespace NovyGorod.Infrastructure.DataAccess.EF;

public class Context : DbContext, IDataAccessProvider
{
    private readonly IConfiguration _configuration;

    public Context(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Context()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("MySQL");
        optionsBuilder.UseMySql(
                connectionString,
                MySqlServerVersion.LatestSupportedServerVersion,
                mySqlDbContextOptionsBuilder =>
                {
                    mySqlDbContextOptionsBuilder.EnableRetryOnFailure();
                })
            .UseLazyLoadingProxies();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig<>).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> Commit()
    {
        return await SaveChangesAsync();
    }

    public IEnumerable<T> GetModified<T>()
        where T : class
    {
        return GetChangeTrackedEntities<T>(state => state == EntityState.Modified);
    }

    public IEnumerable<T> GetModels<T>(ModelState state)
        where T : class
    {
        return ChangeTracker.Entries<T>().Where(state.ToEfEntityStateFilter<T>()).Select(entry => entry.Entity);
    }

    public IEnumerable<T> GetAdded<T>()
        where T : class
    {
        return GetChangeTrackedEntities<T>(state => state == EntityState.Added);
    }

    public IEnumerable<T> GetAddedOrModified<T>()
        where T : class
    {
        return GetChangeTrackedEntities<T>(state =>
            state is EntityState.Modified or EntityState.Added);
    }

    public IEnumerable<T> GetDeleted<T>()
        where T : class
    {
        return GetChangeTrackedEntities<T>(state => state == EntityState.Deleted);
    }

    private IEnumerable<T> GetChangeTrackedEntities<T>(Func<EntityState, bool> stateFunc)
        where T : class
    {
        return ChangeTracker.Entries<T>()
            .Where(e => stateFunc(e.State))
            .Select(e => e.Entity)
            .ToArray();
    }
}