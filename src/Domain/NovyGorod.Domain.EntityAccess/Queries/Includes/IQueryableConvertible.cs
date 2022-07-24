namespace NovyGorod.Domain.EntityAccess.Queries.Includes;

/// <summary>
///     Defines can be converted to queryable.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
public interface IQueryableConvertible<out TEntity>
{
    /// <summary>
    ///     Converts to <see cref="IQueryable{T}"/>.
    /// </summary>
    /// <returns>Converted.</returns>
    IQueryable<TEntity> ToQueryable();
}