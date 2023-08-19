using System.Linq.Expressions;

namespace NovyGorod.Domain.ModelAccess.Queries.Includable;

public interface IThenIncludable<T, TProp> : IIncludable<T>
    where T : class
    where TProp : class
{
    IThenIncludable<T, TNextProp> Then<TNextProp>(Expression<Func<TProp, TNextProp>> selector)
        where TNextProp : class;

    IThenIncludable<T, TNextProp> ThenMany<TNextProp>(Expression<Func<TProp, IEnumerable<TNextProp>>> selector)
        where TNextProp : class;
}