namespace NovyGorod.Domain.Services;

public interface IExecutionContextService
{
    Task<int> GetCurrentLanguageId();

    string GetCurrentUrl();
}