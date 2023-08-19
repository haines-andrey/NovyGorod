namespace NovyGorod.Domain.ModelAccess;

public interface ICommitter
{
    Task<int> Commit(CancellationToken cancellationToken = default);
}