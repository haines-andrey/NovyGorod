using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.EntityAccess.Queries.Results;

[ExcludeFromCodeCoverage]
public class PagingResult
{
    public PagingResult(int skip, int take, int total)
    {
        Skip = skip;
        Take = take;
        TotalCount = total;
    }

    public PagingResult()
    {
    }
    
    public int Skip { get; set; }
    
    public int Take { get; set; }
    
    public int TotalCount { get; set; }
    
    public int PageIndex => Skip / Take;
    
    public int TotalPages => (int)Math.Ceiling((decimal)TotalCount / Take);
    
    public bool HasPreviousPage => PageIndex > 0;
    
    public bool HasNextPage => PageIndex + 1 < TotalPages;
}