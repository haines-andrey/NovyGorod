using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using NovyGorod.Domain.EntityAccess.Queries.Includes;
using NovyGorod.Domain.EntityAccess.Queries.Results;

namespace NovyGorod.Domain.EntityAccess.Queries;

/// <summary>
///     Represents data query to database
///     Encapsulate query parameters.
/// </summary>
/// <typeparam name="TEntity">Type of entities which queried.</typeparam>
[ExcludeFromCodeCoverage]
public class Query<TEntity>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Query{T}" /> class.
    ///     Empty internal constructor to prevent creating query object
    ///     not via <see cref="IQueryBuilder{T}" /> or static initializer.
    /// </summary>
    protected internal Query()
    {
    }

    /// <summary>
    ///     Gets newly constructed empty <see cref="Query{T}"/> object.
    /// </summary>
    public static Query<TEntity> Empty => new();

    /// <summary>
    ///     Gets or sets where clause for queried models.
    /// </summary>
    public Expression<Func<TEntity, bool>> Where { get; set; }

    /// <summary>
    ///     Gets or sets result ordering.
    /// </summary>
    public Func<IQueryable<TEntity>, IQueryable<TEntity>> Ordering { get; set; }

    /// <summary>
    ///     Gets or sets members to include.
    /// </summary>
    public Func<IIncludable<TEntity>, IIncludable<TEntity>> Include { get; set; }

    /// <summary>
    ///     Gets or sets data paging. Null - get all.
    /// </summary>
    public Paging Paging { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether read only intent.
    /// </summary>
    public bool ReadOnly { get; set; }

    /// <summary>
    ///     Gets or sets excluded filters.
    /// </summary>
    public IEnumerable<string> ExcludedFilters { get; set; }
}