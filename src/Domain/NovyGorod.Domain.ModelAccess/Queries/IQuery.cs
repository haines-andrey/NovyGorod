using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries.Includable;
using NovyGorod.Domain.ModelAccess.Queries.Orderable;

namespace NovyGorod.Domain.ModelAccess.Queries;

public interface IQuery<TModel>
    where TModel : class
{
    QueryFilter<TModel> Filter { get; }

    Expression<Func<IOrderable<TModel>, IThenOrderable<TModel>>> Orderable { get; }

    Expression<Func<IIncludable<TModel>, IIncludable<TModel>>> Includable { get; }

    int Skip { get; }

    int Take { get; }

    bool IsReadOnly { get; }
}