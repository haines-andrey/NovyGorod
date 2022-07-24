using System;
using NovyGorod.Domain.Services;

namespace NovyGorodAsp.Services;

public class DateTimeProvider : IDateTimeProvider
{
    private readonly IExecutionContextService _executionContextService;

    public DateTimeProvider(IExecutionContextService executionContextService)
    {
        _executionContextService = executionContextService;
    }

    public DateTimeOffset UtcNow => DateTimeOffset.Now;

    public DateTimeOffset GetDateTimeOffsetOfCurrentUser()
    {
        throw new NotImplementedException();
    }
}