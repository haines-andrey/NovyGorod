using NovyGorod.Domain.Models.Common;
using NovyGorod.Domain.Services;

namespace NovyGorod.Infrastructure.DataAccess.Core.BeforeCommitHandlers;

public class TrackableDateBeforeCommitHandler : IBeforeCommitHandler
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public TrackableDateBeforeCommitHandler(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public Task Handle(IDataAccessProvider dataAccessProvider)
    {
        var now = _dateTimeProvider.UtcNow.DateTime;

        foreach (var added in dataAccessProvider.GetAdded<ITrackable>())
        {
            added.CreatedAt ??= now;
        }

        foreach (var modified in dataAccessProvider.GetModified<ITrackable>())
        {
            modified.UpdatedAt = now;
        }
        
        return Task.CompletedTask;
    }
}