using System.Linq.Expressions;
using NovyGorod.Common.Utils;
using NovyGorod.Domain.ModelAccess.Exceptions;
using NovyGorod.Domain.ModelAccess.Queries.Filters;
using NovyGorod.Domain.ModelAccess.Queries.Includable;
using NovyGorod.Domain.ModelAccess.Queries.Orderable;

namespace NovyGorod.Domain.ModelAccess.Queries.Builders;

public sealed class QueryBuilder<TModel> : IQueryBuilder<TModel>
    where TModel : class
{
    private readonly Query<TModel> _query;

    private QueryBuilder(Query<TModel> query)
    {
        _query = query;
    }

    public static IQueryBuilder<TModel> CreateEmpty()
    {
        return new QueryBuilder<TModel>(Query<TModel>.Empty);
    }

    public static IQueryBuilder<TModel> CreateWithFilter(IQueryFilter<TModel> filter)
    {
        var query = Query<TModel>.Empty;
        query.Filter = filter;

        return new QueryBuilder<TModel>(query);
    }

    public static IQueryBuilder<TModel> CreateWithFilter(Expression<Func<TModel, bool>> filter)
    {
        var query = Query<TModel>.Empty;
        query.Filter = QueryFilter<TModel>.Create(filter);

        return new QueryBuilder<TModel>(query);
    }

    public IQuery<TModel> Build()
    {
        return _query;
    }

    public IQueryBuilder<TModel> Where(IQueryFilter<TModel> filter)
    {
        Contract.IsNotNull<ModelQueryBuildException>(filter);
        Contract.IsNull<ModelQueryBuildException>(_query.Filter);

        _query.Filter = filter;

        return this;
    }

    public IQueryBuilder<TModel> Order(Expression<Func<IOrderable<TModel>, IThenOrderable<TModel>>> orderable)
    {
        Contract.IsNotNull<ModelQueryBuildException>(orderable);
        Contract.IsNull<ModelQueryBuildException>(_query.Orderable);

        _query.Orderable = orderable;

        return this;
    }

    public IQueryBuilder<TModel> Skip(int count)
    {
        Contract.IsTrue<ModelQueryBuildException>(_query.Skip == 0);

        _query.Skip = count;

        return this;
    }

    public IQueryBuilder<TModel> Take(int count)
    {
        Contract.IsTrue<ModelQueryBuildException>(_query.Take == 0);

        _query.Take = count;

        return this;
    }

    public IQueryBuilder<TModel> Include(Expression<Func<IIncludable<TModel>, IIncludable<TModel>>> includable)
    {
        Contract.IsNotNull<ModelQueryBuildException>(includable);
        Contract.IsNull<ModelQueryBuildException>(_query.Orderable);

        _query.Includable = includable;

        return this;
    }

    public IQueryBuilder<TModel> AsReadOnly()
    {
        Contract.IsFalse<ModelQueryBuildException>(_query.IsReadOnly);

        _query.IsReadOnly = true;

        return this;
    }
}