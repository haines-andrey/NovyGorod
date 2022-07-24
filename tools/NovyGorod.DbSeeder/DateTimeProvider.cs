using System;
using NovyGorod.Domain.Services;

namespace NovyGorod.DbSeeder;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;

    public DateTimeOffset GetDateTimeOffsetOfCurrentUser()
    {
        throw new NotImplementedException();
    }
}