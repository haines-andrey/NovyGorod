namespace NovyGorod.Domain.EntityAccess.Queries.Results;

public class SearchResult<TEntity>
{
    public IReadOnlyCollection<TEntity> Items { get; set; } = new List<TEntity>();
    
    public PagingResult Paging { get; set; }
}
