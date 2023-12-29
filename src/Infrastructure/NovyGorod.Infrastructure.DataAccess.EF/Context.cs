using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NovyGorod.Infrastructure.DataAccess.Core;
using NovyGorod.Infrastructure.ModelConfigs;

namespace NovyGorod.Infrastructure.DataAccess.EF;

public class Context : DbContext, IModelsAccessor
{
    private readonly IConfiguration _configuration;

    public Context(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Context()
    {
    }

    public IEnumerable<T> GetModels<T>(ModelState state)
        where T : class
    {
        var entityState = state.ToEntityState();

        return ChangeTracker.Entries<T>().Where(entry => entry.State == entityState).Select(entry => entry.Entity);
    }

    public Task<int> SaveModels(CancellationToken cancellationToken = default)
    {
        return SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var databaseServer = _configuration["DatabaseServer"];

        // if (databaseServer == "MySQL")
        // {
        //     optionsBuilder.UseMySql(
        //         _configuration.GetConnectionString(databaseServer),
        //         MySqlServerVersion.LatestSupportedServerVersion,
        //         mySqlDbContextOptionsBuilder =>
        //         {
        //             mySqlDbContextOptionsBuilder.EnableRetryOnFailure();
        //         });
        // }

        if (databaseServer == "MSSQL")
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString(databaseServer));
        }

        optionsBuilder.UseLazyLoadingProxies();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfig<>).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}