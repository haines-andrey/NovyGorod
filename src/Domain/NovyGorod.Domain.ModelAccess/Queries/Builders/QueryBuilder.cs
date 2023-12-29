using System.Linq.Expressions;
using NovyGorod.Common.Utils;
using NovyGorod.Domain.ModelAccess.Exceptions;
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

    public static IQueryBuilder<TModel> CreateNew()
    {
        return new QueryBuilder<TModel>(Query<TModel>.Empty);
    }

    public IQuery<TModel> Build()
    {
        return _query;
    }

    public IQuery<TModel> Build(int modelId)
    {
        Contract.IsNotNull<ModelQueryBuildException>(modelId);
        Contract.IsNull<ModelQueryBuildException>(_query.ModelIds);
        Contract.IsNull<ModelQueryBuildException>(_query.Filter);
        Contract.IsNull<ModelQueryBuildException>(_query.Orderable);
        Contract.IsTrue<ModelQueryBuildException>(_query.Skip == 0);
        Contract.IsTrue<ModelQueryBuildException>(_query.Take == 0);
        Contract.IsFalse<ModelQueryBuildException>(_query.IsReadOnly);
        _query.ModelIds = new[] {modelId};

        return _query;
    }

    public IQuery<TModel> Build(IEnumerable<int> modelIds)
    {
        var idsList = modelIds?.ToList();
        Contract.IsNotNull<ModelQueryBuildException>(idsList);
        Contract.IsTrue<ModelQueryBuildException>(idsList.Count > 0);
        Contract.IsNull<ModelQueryBuildException>(_query.ModelIds);
        Contract.IsNull<ModelQueryBuildException>(_query.Filter);
        Contract.IsNull<ModelQueryBuildException>(_query.Orderable);
        Contract.IsTrue<ModelQueryBuildException>(_query.Skip == 0);
        Contract.IsTrue<ModelQueryBuildException>(_query.Take == 0);
        Contract.IsFalse<ModelQueryBuildException>(_query.IsReadOnly);
        _query.ModelIds = idsList;

        return _query;
    }

    public IQueryBuilder<TModel> Where(QueryFilter<TModel> filter)
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