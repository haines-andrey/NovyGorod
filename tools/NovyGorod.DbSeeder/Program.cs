using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using NovyGorod.DbSeeder.Seeders;
using NovyGorod.Infrastructure.DataAccess.EF;

namespace NovyGorod.DbSeeder;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();
            
        var builder = new ContainerBuilder();
        builder.RegisterInstance(config).As<IConfiguration>().SingleInstance();
        builder.AddDataAccessEf<Context>();
        builder.RegisterModule<Domain.EntityAccess.Module>();
        builder.RegisterType<Seeder>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<ExecutionContextService>().AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterType<DateTimeProvider>().AsImplementedInterfaces().InstancePerLifetimeScope();

        using (var scope = builder.Build().BeginLifetimeScope())
        {
            var seeder = scope.Resolve<ISeeder>();
            await seeder.Seed();
        }
    }
}