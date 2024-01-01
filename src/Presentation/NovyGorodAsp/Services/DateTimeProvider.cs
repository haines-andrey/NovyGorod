using System;
using NovyGorod.Domain.Services;

namespace NovyGorodAsp.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.Now;
}