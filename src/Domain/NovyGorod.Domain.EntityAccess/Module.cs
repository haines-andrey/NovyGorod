using Autofac;

namespace NovyGorod.Domain.EntityAccess;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EntityAccessService<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(EntityModificationService<>)).AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}