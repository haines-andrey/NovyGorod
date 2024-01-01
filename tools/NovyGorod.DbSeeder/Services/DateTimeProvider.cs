using NovyGorod.Domain.Services;

namespace NovyGorod.DbSeeder.Services;

internal class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.Now;
}