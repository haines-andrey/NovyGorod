namespace NovyGorod.Domain.EntityAccess.Queries.Results;

/// <summary>
///     Interface for paged classes.
/// </summary>
public interface IPaged
{
    /// <summary>
    ///     Gets or sets paging information.
    /// </summary>
    PagingResult Paging { get; set; }
}