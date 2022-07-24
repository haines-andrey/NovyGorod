using System.Linq.Expressions;
using System.Reflection;

namespace NovyGorod.Common.Utils.Expressions;

public static class ExpressionsUtils
{
    public static Expression<Func<T, bool>> AndAlso<T>(
        Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
    {
        return GetAggregatedExpression(Expression.AndAlso, expr1, expr2);
    }

    public static Expression<Func<T, bool>> Or<T>(
        Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
    {
        return GetAggregatedExpression(Expression.Or, expr1, expr2);
    }

    public static Expression<Func<TEntity, bool>> PropertyEqual<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> propertySelector,
        TProperty filterValue)
    {
        return GetComparePropertyAndValueExpression(ExpressionType.Equal, propertySelector, filterValue);
    }

    public static Expression<Func<TEntity, bool>> PropertyNotEqual<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> propertySelector,
        TProperty filterValue)
    {
        return GetComparePropertyAndValueExpression(ExpressionType.NotEqual, propertySelector, filterValue);
    }

    public static Expression<Func<TEntity, bool>> Contains<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> propertySelector,
        List<TProperty> values)
    {
        var methodInfo =
            typeof(List<TProperty>).GetMethod(nameof(List<TProperty>.Contains), new[] { typeof(TProperty) });
        if (methodInfo == null)
        {
            throw new InvalidOperationException();
        }

        var list = Expression.Constant(values);
        var body = Expression.Call(list, methodInfo, propertySelector.Body);

        return Expression.Lambda<Func<TEntity, bool>>(body, propertySelector.Parameters);
    }

    public static MemberInfo GetMemberInfo(Expression expression)
    {
        return ExpressionMemberResolver.ResolveMemberInfo(expression);
    }

    public static Expression<Func<TEntity, bool>> GetComparePropertyAndValueExpression<TEntity, TProperty>(
        ExpressionType expressionType,
        Expression<Func<TEntity, TProperty>> propertySelector,
        TProperty filterValue)
    {
        var converted = Expression.Convert(Expression.Constant(filterValue), propertySelector.ReturnType);
        var binaryExpression = Expression.MakeBinary(expressionType, propertySelector.Body, converted);

        return Expression.Lambda<Func<TEntity, bool>>(binaryExpression, propertySelector.Parameters);
    }

    public static Expression GetProperty(string field, Expression entityTypeParameterExpression)
    {
        return field.Split('.').Aggregate(entityTypeParameterExpression, Expression.Property);
    }

    private static Expression<Func<T, bool>> GetAggregatedExpression<T>(
        Func<Expression, Expression, BinaryExpression> aggregate,
        Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
        var left = leftVisitor.Visit(expr1.Body);

        var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
        var right = rightVisitor.Visit(expr2.Body);

        return Expression.Lambda<Func<T, bool>>(aggregate(left, right), parameter);
    }
}
