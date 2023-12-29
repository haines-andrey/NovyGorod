using Autofac;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Attachments;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Posts;
using NovyGorod.Infrastructure.DataAccess.Core;
using NovyGorod.Infrastructure.DataAccess.EF.Repositories;

namespace NovyGorod.Infrastructure.DataAccess.EF;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder RegisterDbContext<TDbContext>(this ContainerBuilder builder)
        where TDbContext : DbContext, IModelsAccessor 
    {
        builder.RegisterType<TDbContext>().As<DbContext>()
            .InstancePerLifetimeScope()
            .AsImplementedInterfaces();

        return builder;
    }

    private static ContainerBuilder RegisterRepository<TEntity>(this ContainerBuilder builder)
        where TEntity : class
    {
        builder.RegisterType<EfRepository<TEntity>>().AsImplementedInterfaces().InstancePerLifetimeScope();

        return builder;
    }
    
    public static ContainerBuilder RegisterModelsRepositories(this ContainerBuilder builder)
    {
        builder.RegisterRepository<Language>();
        builder.RegisterRepository<Post>();
        builder.RegisterRepository<MediaData>();
        builder.RegisterRepository<Attachment>();

        return builder;
    }
}