using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.Models;

namespace NovyGorod.DbSeeder.Queries;

internal class MediaDataQueryParams : BaseQueryParameters<MediaData>
{
    public string Url { get; set; }

    protected override void AddFilters()
    {
        Filter(x => x.Url == Url);
    }
}