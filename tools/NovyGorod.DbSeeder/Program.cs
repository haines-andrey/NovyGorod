using Autofac;
using NovyGorod.DbSeeder;

var container = AppContainerBuilder.Build();
var seeder = container.BeginLifetimeScope().Resolve<Seeder>();
await seeder.Seed();

Console.WriteLine("seeded");