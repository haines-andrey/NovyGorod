namespace NovyGorod.Domain.EntityAccess.Queries.Results;

/// <summary>
///     Represents result of query to database.
/// </summary>
/// <typeparam name="TEntity">Type of model.</typeparam>
public class SearchResult<TEntity> : IPaged
{
    /// <summary>
    ///     Gets or sets result of query.
    /// </summary>
    public IReadOnlyCollection<TEntity> Items { get; set; } = new List<TEntity>();

    /// <summary>
    ///     Gets or sets paging information.
    /// </summary>
    public PagingResult Paging { get; set; }

    /// <summary>
    ///     Creates an empty instance of <see cref="SearchResult{T}" />.
    /// </summary>
    /// <returns>An empty instance of <see cref="SearchResult{T}" />.</returns>
    public static SearchResult<TEntity> Empty()
    {
        return new SearchResult<TEntity>();
    }

    /// <summary>
    ///     Creates new instance of <see cref="SearchResult{T}" /> from <paramref name="items" />.
    /// </summary>
    /// <param name="items">Full search result.</param>
    /// <returns>Instantiated <see cref="SearchResult{T}" />.</returns>
    public static SearchResult<TEntity> Build(IReadOnlyCollection<TEntity> items)
    {
        return new SearchResult<TEntity> { Items = items };
    }
}
