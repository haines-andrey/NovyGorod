using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Services;

namespace NovyGorod.Infrastructure.DataAccess.Core.BeforeCommitHandlers;

internal class TrackableModelsBeforeCommitHandler : IBeforeCommitHandler
{
    private readonly IModelsAccessor _modelsAccessor;
    private readonly IDateTimeProvider _dateTimeProvider;

    public TrackableModelsBeforeCommitHandler(
        IModelsAccessor modelsAccessor,
        IDateTimeProvider dateTimeProvider)
    {
        _modelsAccessor = modelsAccessor;
        _dateTimeProvider = dateTimeProvider;
    }

    public Task Handle()
    {
        var addedModels = _modelsAccessor.GetModels<ITrackable>(ModelState.Added);
        var editedModels = _modelsAccessor.GetModels<ITrackable>(ModelState.Modified);
        var now = _dateTimeProvider.UtcNow.DateTime;

        foreach (var added in addedModels)
        {
            added.CreatedAt = now;
        }

        foreach (var modified in editedModels)
        {
            modified.UpdatedAt = now;
        }
        
        return Task.CompletedTask;
    }
}