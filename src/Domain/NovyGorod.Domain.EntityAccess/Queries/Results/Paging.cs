using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.EntityAccess.Queries.Results;

[ExcludeFromCodeCoverage]
public class Paging
{
    public Paging(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }

    public Paging()
    {
    }
    
    public int Skip { get; set; }
    
    public int Take { get; set; }
    
    public static Paging FromTake(int take)
    {
        return new Paging(0, take);
    }
}