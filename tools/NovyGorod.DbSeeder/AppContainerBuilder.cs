using Autofac;
using Microsoft.Extensions.Configuration;
using NovyGorod.Infrastructure.DataAccess.EF;
using EntityAccessModule = NovyGorod.Domain.EntityAccess.Module;
using DbSeederModule = NovyGorod.DbSeeder.Module;

namespace NovyGorod.DbSeeder;

internal static class AppContainerBuilder
{
    public static IContainer Build()
    {
        var builder = new ContainerBuilder();
        ConfigureContainer(builder);

        return builder.Build();
    }

    private static void ConfigureContainer(ContainerBuilder builder)
    {
        var config = BuildConfig();
        builder.Register(_ => config);
        builder.AddDataAccessEf<Context>();
        builder.RegisterModule<EntityAccessModule>();
        builder.RegisterModule<Module>();
    }

    private static IConfiguration BuildConfig()
    {
        var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

        return configBuilder.Build();
    }
}