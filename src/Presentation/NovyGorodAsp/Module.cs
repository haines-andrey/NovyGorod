using Autofac;
using NovyGorodAsp.Services;

namespace NovyGorodAsp;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DateTimeProvider>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<ExecutionContextAccessor>().AsImplementedInterfaces().InstancePerLifetimeScope()
            .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
    }
}