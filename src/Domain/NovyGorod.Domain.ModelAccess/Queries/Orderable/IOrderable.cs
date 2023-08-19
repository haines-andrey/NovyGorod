using System.Linq.Expressions;

namespace NovyGorod.Domain.ModelAccess.Queries.Orderable;

public interface IOrderable<T>
    where T : class
{
    IThenOrderable<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector);

    IThenOrderable<T> OrderByDesc<TKey>(Expression<Func<T, TKey>> keySelector);
}