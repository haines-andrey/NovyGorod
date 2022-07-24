using System.Threading.Tasks;

namespace NovyGorod.DbSeeder.Seeders;

public interface ISeeder
{
    Task Seed();
}