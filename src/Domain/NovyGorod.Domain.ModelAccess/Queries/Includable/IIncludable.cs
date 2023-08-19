using System.Linq.Expressions;

namespace NovyGorod.Domain.ModelAccess.Queries.Includable;

public interface IIncludable<TModel>
    where TModel : class
{
    IThenIncludable<TModel, TProp> Include<TProp>(Expression<Func<TModel, TProp>> selector)
        where TProp : class;

    IThenIncludable<TModel, TProp> IncludeMany<TProp>(Expression<Func<TModel, IEnumerable<TProp>>> selector)
        where TProp : class;
}