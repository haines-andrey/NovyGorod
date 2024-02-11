namespace NovyGorod.Domain.Services;

public interface IExecutionContextAccessor
{
    Task<int> GetCurrentLanguageId();

    string GetCurrentUrl();
}