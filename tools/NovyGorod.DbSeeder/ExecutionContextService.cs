using System;
using System.Threading.Tasks;
using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Services;

namespace NovyGorod.DbSeeder;

public class ExecutionContextService : IExecutionContextService
{
    public TimeZoneInfo GetCurrentTimeZoneInfo()
    {
        return TimeZoneInfo.Local;
    }

    public Task<int> GetCurrentLanguageId()
    {
        return Task.FromResult(1);
    }

    public string GetCurrentUrl()
    {
        throw new NotImplementedException();
    }
}