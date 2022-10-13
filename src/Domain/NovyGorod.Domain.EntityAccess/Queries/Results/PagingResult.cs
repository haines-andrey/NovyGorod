using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.EntityAccess.Queries.Results;

[ExcludeFromCodeCoverage]
public class PagingResult
{
    public PagingResult(int skip, int pageSize, int total)
    {
        Skip = skip;
        PageSize = pageSize;
        Total = total;
    }

    public int Skip { get; init; }
    
    public int PageSize { get; init; }
    
    public int Total { get; init; }

    public int PageIndex => (int) Math.Ceiling((decimal)Skip / PageSize);
    
    public int TotalPages => (int)Math.Ceiling((decimal)Total / PageSize);
    
    public bool HasPreviousPage => PageIndex > 0;
    
    public bool HasNextPage => PageIndex + 1 < TotalPages;
}