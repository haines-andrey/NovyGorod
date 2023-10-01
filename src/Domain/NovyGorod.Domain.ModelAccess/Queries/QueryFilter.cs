using System.Linq.Expressions;
using NovyGorod.Common.Utils.Expressions;

namespace NovyGorod.Domain.ModelAccess.Queries;

public sealed record QueryFilter<TModel>
{
    public Expression<Func<TModel, bool>> Predicate { get; private init; }

    public static QueryFilter<TModel> Create(Expression<Func<TModel, bool>> predicate)
    {
        return new QueryFilter<TModel> {Predicate = predicate};
    }

    public static QueryFilter<TModel> operator &(QueryFilter<TModel> left, QueryFilter<TModel> right)
    {
        var predicate = ExpressionsUtils.AndAlso(left.Predicate, right.Predicate);

        return Create(predicate);
    }

    public static QueryFilter<TModel> operator |(QueryFilter<TModel> left, QueryFilter<TModel> right)
    {
        var predicate = ExpressionsUtils.Or(left.Predicate, right.Predicate);

        return Create(predicate);
    }

    public static QueryFilter<TModel> operator !(QueryFilter<TModel> queryFilter)
    {
        var expression = queryFilter.Predicate;
        var parameter = expression.Parameters.Single();
        var body = Expression.Not(expression.Body);

        return Create(Expression.Lambda<Func<TModel, bool>>(body, parameter));
    }
}