using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries.Includable;
using NovyGorod.Domain.ModelAccess.Queries.Orderable;

namespace NovyGorod.Domain.ModelAccess.Queries.Builders;

[ExcludeFromCodeCoverage]
internal sealed record Query<TModel> : IQuery<TModel>
    where TModel : class
{
    public static Query<TModel> Empty => new();

    public IReadOnlyCollection<int> ModelIds { get; set; }

    public QueryFilter<TModel> Filter { get; set; }

    public Expression<Func<IOrderable<TModel>, IThenOrderable<TModel>>> Orderable { get; set; }

    public Expression<Func<IIncludable<TModel>, IIncludable<TModel>>> Includable { get; set; }

    public int Skip { get; set; }

    public int Take { get; set; }

    public bool IsReadOnly { get; set; }
}