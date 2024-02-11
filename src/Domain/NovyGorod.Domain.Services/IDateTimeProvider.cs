namespace NovyGorod.Domain.Services;

public interface IDateTimeProvider
{
    DateTimeOffset UtcNow { get; }
}