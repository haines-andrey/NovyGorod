using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.EntityAccess.Queries.Results;

/// <summary>
///     Represents paging information of query result.
/// </summary>
[ExcludeFromCodeCoverage]
public class PagingResult
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PagingResult" /> class.
    /// </summary>
    /// <param name="skip">Skipped models count.</param>
    /// <param name="take">Requested count to take.</param>
    /// <param name="total">Total count of models which satisfies filtering.</param>
    public PagingResult(int skip, int take, int total)
    {
        Skip = skip;
        Take = take;
        TotalCount = total;
    }

    public PagingResult()
    {
    }

    /// <summary>
    ///     Gets or sets count of skipped entities.
    /// </summary>
    public int Skip { get; set; }

    /// <summary>
    ///     Gets or sets count of taken portion.
    /// </summary>
    public int Take { get; set; }

    /// <summary>
    ///     Gets or sets total count in database.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    ///     Gets a value indicating whether current portion page index.
    /// </summary>
    public int PageIndex => Skip / Take;

    /// <summary>
    ///     Gets a value indicating whether total count of pages for current portion.
    /// </summary>
    public int TotalPages => (int)Math.Ceiling((decimal)TotalCount / Take);

    /// <summary>
    ///     Gets a value indicating whether is previous portion with same <see cref="Take" /> portion exists.
    /// </summary>
    public bool HasPreviousPage => PageIndex > 0;

    /// <summary>
    ///     Gets a value indicating whether is next portion with same <see cref="Take" /> portion exists.
    /// </summary>
    public bool HasNextPage => PageIndex + 1 < TotalPages;
}