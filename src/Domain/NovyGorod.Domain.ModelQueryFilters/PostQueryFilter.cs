using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries.Filters;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.Domain.ModelQueryFilters;

public sealed class PostQueryFilter : IQueryFilter<Post>
{
    public Expression<Func<Post, bool>> Expression { get; }
}