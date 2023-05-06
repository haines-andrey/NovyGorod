using NovyGorod.DbSeeder.Dtos;
using NovyGorod.DbSeeder.Queries;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.Models;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class MediaDataFactory : IEntityFactory<MediaData, MediaDataDto>
{
    private readonly IEntityAccessService<MediaData> _mediaDataAccessService;

    public MediaDataFactory(IEntityAccessService<MediaData> mediaDataAccessService)
    {
        _mediaDataAccessService = mediaDataAccessService;
    }

    public async Task<MediaData> Create(MediaDataDto dto)
    {
        var existing = await GetExisingMediaData(dto.Url);

        return existing ?? new MediaData {Type = dto.Type, IsLocal = dto.IsLocal, Url = dto.Url};
    }

    private Task<MediaData> GetExisingMediaData(string url)
    {
        var query = new MediaDataQueryParams {Url = url};

        return _mediaDataAccessService.GetSingleOrDefault(query);
    }
}