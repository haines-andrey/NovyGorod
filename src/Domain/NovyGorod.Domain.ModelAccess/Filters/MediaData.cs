using System.Linq.Expressions;
using NovyGorod.Domain.ModelAccess.Queries;
using MediaDataModel = NovyGorod.Domain.Models.MediaData;

namespace NovyGorod.Domain.ModelAccess.Filters;

public static class MediaData
{
    public static QueryFilter<MediaDataModel> IdIs(int id) => Common.IdIs<MediaDataModel>(id);

    public static QueryFilter<MediaDataModel> IdIsIn(IEnumerable<int> ids) => Common.IdIsIn<MediaDataModel>(ids);

    public static QueryFilter<MediaDataModel> UrlIs(string url) => Create(mediaData => mediaData.Url == url);

    private static QueryFilter<MediaDataModel> Create(Expression<Func<MediaDataModel, bool>> expression) =>
        QueryFilter<MediaDataModel>.Create(expression);
}