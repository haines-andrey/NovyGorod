namespace NovyGorod.Infrastructure.DataAccess.Core;

public interface IDataAccessProvider
{
    Task<int> Commit();
    
    IEnumerable<T> GetModified<T>()
        where T : class;
    
    IEnumerable<T> GetModels<T>(ModelState state)
        where T : class;
    
    IEnumerable<T> GetAdded<T>()
        where T : class;
    
    IEnumerable<T> GetAddedOrModified<T>()
        where T : class;
    
    IEnumerable<T> GetDeleted<T>()
        where T : class;
}
