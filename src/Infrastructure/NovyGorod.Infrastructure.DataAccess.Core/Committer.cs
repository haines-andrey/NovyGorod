using NovyGorod.Domain.ModelAccess;
using NovyGorod.Infrastructure.DataAccess.Core.BeforeCommitHandlers;

namespace NovyGorod.Infrastructure.DataAccess.Core;

internal class Committer : ICommitter
{
    private readonly IModelsAccessor _modelsAccessor;
    private readonly IEnumerable<IBeforeCommitHandler> _beforeCommitHandlers;

    public Committer(
        IModelsAccessor modelsAccessor,
        IEnumerable<IBeforeCommitHandler> beforeCommitHandlers)
    {
        _modelsAccessor = modelsAccessor;
        _beforeCommitHandlers = beforeCommitHandlers;
    }

    public async Task<int> Commit(CancellationToken cancellationToken = default)
    {
        foreach (var beforeCommitHandler in _beforeCommitHandlers)
        {
            await beforeCommitHandler.Handle();
        }
        
        var numberOfModels = await _modelsAccessor.SaveModels(cancellationToken);

        return numberOfModels;
    }
}