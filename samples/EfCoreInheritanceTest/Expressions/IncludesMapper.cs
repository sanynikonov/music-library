using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace EfCoreInheritanceTest.Expressions;

public class IncludesMapper<TSource, TTarget> : ExpressionVisitor
{
    private ReadOnlyCollection<ParameterExpression> _parameters;

    protected override Expression VisitParameter(ParameterExpression node) =>
        _parameters?.FirstOrDefault(p => p.Name == node.Name)
            ?? (node.Type == typeof(TSource)
                ? Expression.Parameter(typeof(TTarget), node.Name)
                : node);

    protected override Expression VisitLambda<T>(Expression<T> node)
    {
        _parameters = VisitAndConvert(node.Parameters, nameof(VisitLambda));
        var converted = Expression.Convert(Visit(node.Body), typeof(object));
        return Expression.Lambda(converted, _parameters);
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        if (node.Member.DeclaringType == typeof(TSource))
        {
            var propertyInfo = typeof(TTarget).GetProperties().First(p => p.DeclaringType == typeof(TTarget));

            return Expression.Property(Visit(node.Expression)!, propertyInfo);
        }

        return base.VisitMember(node);
    }
}

public static class ExpressionExtensions
{
    public static Expression<Func<TTarget, object>> ChangeType<TSource, TTarget>(this Expression<Func<TSource, object>> root)
    {
        if (typeof(TTarget) == typeof(TSource))
            return (Expression<Func<TTarget, object>>)(Expression)root;

        var visitor = new IncludesMapper<TSource, TTarget>();
        return (Expression<Func<TTarget, object>>)visitor.Visit(root);
    }
}