using Autofac;
using NovyGorod.Infrastructure.DataAccess.Core.RepositoryFactories;

namespace NovyGorod.Infrastructure.DataAccess.Core;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder AddDataAccessCore(this ContainerBuilder builder)
    {
        builder.RegisterType<UnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<RepositoryFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();

        return builder;
    }
}