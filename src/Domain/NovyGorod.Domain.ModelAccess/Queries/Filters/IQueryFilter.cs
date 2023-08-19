using System.Linq.Expressions;

namespace NovyGorod.Domain.ModelAccess.Queries.Filters;

public interface IQueryFilter<TModel>
    where TModel : class
{
    Expression<Func<TModel, bool>> Expression { get; }
}