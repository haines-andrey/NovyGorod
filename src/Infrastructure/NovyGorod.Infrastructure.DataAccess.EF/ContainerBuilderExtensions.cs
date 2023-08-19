using Autofac;
using Microsoft.EntityFrameworkCore;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Attachments;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Models.Posts;
using NovyGorod.Infrastructure.DataAccess.Core;
using NovyGorod.Infrastructure.DataAccess.Core.BeforeCommitHandlers;
using NovyGorod.Infrastructure.DataAccess.EF.Repositories;

namespace NovyGorod.Infrastructure.DataAccess.EF;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder AddDataAccessEf<TAccessProvider>(this ContainerBuilder builder)
        where TAccessProvider : class, IDataAccessProvider 
    {
        builder.RegisterType<TAccessProvider>()
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope()
            .AsImplementedInterfaces();

        builder.AddDataAccessCore()
            .AddRepositories()
            .AddBeforeCommitHandler<TrackableDateBeforeCommitHandler>();

        return builder;
    }

    private static ContainerBuilder AddBeforeCommitHandler<THandler>(this ContainerBuilder builder)
        where THandler : IBeforeCommitHandler
    {
        builder.RegisterType<THandler>().AsImplementedInterfaces().InstancePerLifetimeScope();

        return builder;
    }

    private static ContainerBuilder AddGenericRepository<TEntity>(this ContainerBuilder builder)
        where TEntity : class
    {
        builder.RegisterType<EfRepository<TEntity>>().AsImplementedInterfaces().InstancePerLifetimeScope();

        return builder;
    }
    
    private static ContainerBuilder AddRepositories(this ContainerBuilder builder)
    {
        builder.AddGenericRepository<Language>();
        builder.AddGenericRepository<Post>();
        builder.AddGenericRepository<MediaData>();
        builder.AddGenericRepository<Attachment>();

        return builder;
    }
}