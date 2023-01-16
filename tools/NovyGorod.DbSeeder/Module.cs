using Autofac;
using NovyGorod.DbSeeder.DtoParsers;
using NovyGorod.DbSeeder.EntityFactories;
using NovyGorod.DbSeeder.Services;

namespace NovyGorod.DbSeeder;

internal class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Seeder>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<DateTimeProvider>().AsImplementedInterfaces().InstancePerLifetimeScope();

        builder.RegisterType<DefaultDataService>().AsImplementedInterfaces().SingleInstance();
        builder.RegisterType<PostParser>().AsImplementedInterfaces().InstancePerLifetimeScope();

        builder.RegisterType<PostFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<PostTranslationFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<PostBlockFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<PostBlockTranslationFactory>().AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}