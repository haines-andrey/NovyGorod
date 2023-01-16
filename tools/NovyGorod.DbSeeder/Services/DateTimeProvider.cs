using NovyGorod.Domain.Services;

namespace NovyGorod.DbSeeder.Services;

internal class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.Now;

    public DateTimeOffset GetDateTimeOffsetOfCurrentUser()
    {
        throw new NotImplementedException();
    }
}