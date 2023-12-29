using Autofac;
using NovyGorod.Infrastructure.DataAccess.Core.BeforeCommitHandlers;

namespace NovyGorod.Infrastructure.DataAccess.Core;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder RegisterModelsAccessCore(this ContainerBuilder builder)
    {
        builder.RegisterType<Committer>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<TrackableModelsBeforeCommitHandler>().AsImplementedInterfaces().InstancePerLifetimeScope();

        return builder;
    }
}