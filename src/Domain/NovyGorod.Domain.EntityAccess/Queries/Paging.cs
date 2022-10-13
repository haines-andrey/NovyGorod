using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.EntityAccess.Queries;

[ExcludeFromCodeCoverage]
public class Paging
{
    public Paging(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }

    public int Skip { get; init; }

    public int Take { get; init; }
}