using System.Linq.Expressions;

namespace NovyGorod.Domain.ModelAccess.Queries.Filters;

public sealed class QueryFilter<TModel> : IQueryFilter<TModel>
    where TModel : class
{
    public Expression<Func<TModel, bool>> Expression { get; private set; }

    public static IQueryFilter<TModel> Create(Expression<Func<TModel, bool>> expression)
    {
        return new QueryFilter<TModel> { Expression = expression };
    }
}