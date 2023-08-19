using NovyGorod.Domain.ModelAccess;

namespace NovyGorod.Infrastructure.DataAccess.Core;

public interface IDataAccessProvider : ICommitter
{
    IEnumerable<T> GetModels<T>(ModelState state)
        where T : class;

    IEnumerable<T> GetAdded<T>()
        where T : class;

    IEnumerable<T> GetModified<T>()
        where T : class;

    IEnumerable<T> GetAddedOrModified<T>()
        where T : class;
    
    IEnumerable<T> GetDeleted<T>()
        where T : class;
}
