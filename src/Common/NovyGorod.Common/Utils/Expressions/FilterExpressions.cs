using System.Linq.Expressions;

namespace NovyGorod.Common.Utils.Expressions;

public static class FilterExpressions
{
    public static Expression<Func<TEntity, bool>> GetEqualFilterExpression<TEntity, TKey>(
        Expression<Func<TEntity, TKey>> keySelector,
        TKey value)
    {
        var parameter = Expression.Parameter(typeof(TEntity));

        return Expression.Lambda<Func<TEntity, bool>>(
            Expression.Equal(
                Expression.Invoke(keySelector, parameter),
                Expression.Constant(value, typeof(TKey))),
            parameter);
    }

    public static Expression<Func<TEntity, bool>> GetDateFilterExpression<TEntity>(
        Expression<Func<TEntity, DateTime?>> keySelector,
        DateTime referenceDate)
    {
        var parameter = Expression.Parameter(typeof(TEntity));
        var getKeyExpression = Expression.Invoke(keySelector, parameter);

        return Expression.Lambda<Func<TEntity, bool>>(
            Expression.And(
                Expression.LessThanOrEqual(Expression.Constant(referenceDate, typeof(DateTime?)), getKeyExpression),
                Expression.LessThanOrEqual(
                    getKeyExpression,
                    Expression.Constant(referenceDate.AddDays(1), typeof(DateTime?)))), parameter);
    }

    public static Expression<Func<TEntity, bool>> GetStringContainsExpression<TEntity>(
        Expression<Func<TEntity, string>> keySelector,
        string substring)
    {
        var parameter = Expression.Parameter(typeof(TEntity));
        var getKeyExpression = Expression.Invoke(keySelector, parameter);
        var method = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
        if (method == null)
        {
            throw new InvalidOperationException();
        }

        var substringExpression = Expression.Constant(substring, typeof(string));
        var containsMethodExp = Expression.Call(getKeyExpression, method, substringExpression);

        return Expression.Lambda<Func<TEntity, bool>>(containsMethodExp, parameter);
    }
}
