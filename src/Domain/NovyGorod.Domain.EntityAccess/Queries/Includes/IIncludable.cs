using System.Linq.Expressions;

namespace NovyGorod.Domain.EntityAccess.Queries.Includes;

/// <summary>
///     Contract for classes which implements including objects.
/// </summary>
/// <typeparam name="T">Type of source model.</typeparam>
public interface IIncludable<T> : IQueryableConvertible<T>
{
    /// <summary>
    ///     Includes <paramref name="accessor" /> to result.
    /// </summary>
    /// <typeparam name="TProp">Type of including property.</typeparam>
    /// <param name="accessor">Property accessing expression.</param>
    /// <returns>Includable to included nested property.</returns>
    IThenIncludable<T, TProp> Include<TProp>(Expression<Func<T, TProp>> accessor)
        where TProp : class;

    /// <summary>
    ///     Includes <paramref name="accessor" /> to result.
    /// </summary>
    /// <typeparam name="TProp">Type of including property.</typeparam>
    /// <param name="accessor">Property accessing expression.</param>
    /// <returns>Includable to included nested property.</returns>
    IThenIncludable<T, TProp> IncludeMany<TProp>(Expression<Func<T, IEnumerable<TProp>>> accessor)
        where TProp : class;
}