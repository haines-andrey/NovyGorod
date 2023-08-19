using System.Diagnostics.CodeAnalysis;

namespace NovyGorod.Domain.ModelAccess.Queries.Results;

[ExcludeFromCodeCoverage]
public sealed record Paging
{
    public int Skip { get; init; }
    
    public int PageSize { get; init; }
    
    public int Total { get; init; }

    public int PageIndex => (int) Math.Ceiling((decimal)Skip / PageSize);
    
    public int TotalPages => (int)Math.Ceiling((decimal)Total / PageSize);
    
    public bool HasPreviousPage => PageIndex > 0;
    
    public bool HasNextPage => PageIndex + 1 < TotalPages;
}