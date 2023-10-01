using NovyGorod.DbSeeder.Dtos;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.Models;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class MediaDataFactory : IEntityFactory<MediaData, MediaDataDto>
{
    private readonly IReadOnlyRepository<MediaData> _repository;

    public MediaDataFactory(IReadOnlyRepository<MediaData> repository)
    {
        _repository = repository;
    }

    public async Task<MediaData> Create(MediaDataDto dto)
    {
        var existing = await GetExisingMediaData(dto.Url);

        return existing ?? new MediaData {Type = dto.Type, IsLocal = dto.IsLocal, Url = dto.Url};
    }

    private Task<MediaData> GetExisingMediaData(string url)
    {
        var queryFilter = Filters.MediaData.UrlIs(url);
        var query = QueryBuilder<MediaData>.CreateWithFilter(queryFilter).Build();

        return _repository.GetSingleOrDefault(query);
    }
}