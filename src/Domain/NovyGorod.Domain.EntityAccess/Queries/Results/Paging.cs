using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.EntityAccess.Queries.Results;

/// <summary>
/// Paging query parameters.
/// </summary>
[ExcludeFromCodeCoverage]
public class Paging
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Paging" /> class.
    /// </summary>
    /// <param name="skip">Count to skip.</param>
    /// <param name="take">Count to take.</param>
    public Paging(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }

    public Paging()
    {
    }

    /// <summary>
    /// Gets or sets count to skip.
    /// </summary>
    public int Skip { get; set; }

    /// <summary>
    /// Gets or sets count to take.
    /// </summary>
    public int Take { get; set; }

    /// <summary>
    /// Creates new instance of <see cref="Paging" /> with <see cref="Skip" /> = 0
    /// and <see cref="Take" /> = <paramref name="take" />.
    /// </summary>
    /// <param name="take">Count to take.</param>
    /// <returns>New instance of <see cref="Paging" />.</returns>
    public static Paging FromTake(int take)
    {
        return new Paging(0, take);
    }
}