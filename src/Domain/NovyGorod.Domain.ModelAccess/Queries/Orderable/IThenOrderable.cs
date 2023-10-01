using System.Linq.Expressions;

namespace NovyGorod.Domain.ModelAccess.Queries.Orderable;

public interface IThenOrderable<T>
{
    IThenOrderable<T> ThenBy<TKey>(Expression<Func<T, TKey>> keySelector);

    IThenOrderable<T> ThenByDesc<TKey>(Expression<Func<T, TKey>> keySelector);
}