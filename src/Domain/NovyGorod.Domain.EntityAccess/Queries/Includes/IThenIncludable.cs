using System.Linq.Expressions;

namespace NovyGorod.Domain.EntityAccess.Queries.Includes;

/// <summary>
///     Contract for classes which implements including for nested objects.
/// </summary>
/// <typeparam name="TParent">Type of object which includes references.</typeparam>
/// <typeparam name="TProp">Type of previously included member.</typeparam>
public interface IThenIncludable<TParent, TProp>  : IIncludable<TParent>
    where TProp : class
{
    /// <summary>
    ///     Includes additional nested property.
    /// </summary>
    /// <typeparam name="TNextProp">Included nested property type.</typeparam>
    /// <param name="accessor">Accessor to nested property.</param>
    /// <returns>Includable to include additional nested property.</returns>
    IThenIncludable<TParent, TNextProp> ThenInclude<TNextProp>(Expression<Func<TProp, TNextProp>> accessor)
        where TNextProp : class;

    /// <summary>
    ///     Includes additional nested property.
    /// </summary>
    /// <typeparam name="TNextProp">Included nested property type.</typeparam>
    /// <param name="accessor">Accessor to nested property.</param>
    /// <returns>Includable to include additional nested property.</returns>
    IThenIncludable<TParent, TNextProp> ThenMany<TNextProp>(Expression<Func<TProp, IEnumerable<TNextProp>>> accessor)
        where TNextProp : class;
}