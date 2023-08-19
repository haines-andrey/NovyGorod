using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries.Filters;
using NovyGorod.Domain.ModelAccess.Queries.Includable;
using NovyGorod.Domain.ModelAccess.Queries.Orderable;

namespace NovyGorod.Domain.ModelAccess.Queries.Builders;

public interface IQueryBuilder<TModel>
    where TModel : class
{
    IQuery<TModel> Build();

    IQueryBuilder<TModel> Where(IQueryFilter<TModel> filter);

    IQueryBuilder<TModel> Order(Expression<Func<IOrderable<TModel>, IThenOrderable<TModel>>> orderable);

    IQueryBuilder<TModel> Skip(int count);
    
    IQueryBuilder<TModel> Take(int count);

    IQueryBuilder<TModel> Include(Expression<Func<IIncludable<TModel>, IIncludable<TModel>>> includable);

    IQueryBuilder<TModel> AsReadOnly();
}