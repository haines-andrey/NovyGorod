using System.Linq.Expressions;
using System.Reflection;

namespace NovyGorod.Common.Utils.Expressions;

internal class ExpressionMemberResolver
{
    private readonly Expression _expression;
    private LambdaExpression _lambda;
    private MemberExpression _memberExpression;

    private ExpressionMemberResolver(Expression expression)
    {
        _expression = expression;
    }

    public static MemberInfo ResolveMemberInfo(Expression expression)
    {
        return new ExpressionMemberResolver(expression).GetMemberInfo();
    }

    private MemberInfo GetMemberInfo()
    {
        CastToLambda();
        ResolveMemberExpression();

        return _memberExpression.Member;
    }

    private void ResolveMemberExpression()
    {
        switch (_lambda.Body.NodeType)
        {
            case ExpressionType.Convert:
            {
                ResolveLambdaConvert();

                break;
            }

            case ExpressionType.MemberAccess:
            {
                ResolveLambdaMemberAccess();

                break;
            }

            default:
                throw new ArgumentException(
                    $"Unable to resolve member expression for expression of type: {_lambda.NodeType.ToString()}");
        }
    }

    private void ResolveLambdaConvert()
    {
        var operand = (_lambda.Body as UnaryExpression)?.Operand;
        _memberExpression = operand as MemberExpression
                            ?? throw new ArgumentException(
                                $"Unable convert operand of type {operand?.Type} to {nameof(MemberExpression)}");
    }

    private void ResolveLambdaMemberAccess()
    {
        _memberExpression = _lambda.Body as MemberExpression
                            ?? throw new ArgumentException(
                                $"Unable convert expression of type {_lambda.Body.Type} to {nameof(MemberExpression)}");
    }

    private void CastToLambda()
    {
        if (_expression is LambdaExpression lambda)
        {
            _lambda = lambda;

            return;
        }

        throw new ArgumentException($"Unable to resolve expression of non-lambda type: {_expression.GetType().Name}");
    }
}
