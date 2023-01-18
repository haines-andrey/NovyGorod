using NovyGorod.Common.Extensions;
using NovyGorod.DbSeeder.Dtos;
using NovyGorod.DbSeeder.Services;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class PostTranslationFactory : IEntityFactory<PostTranslation, PostDto>
{
    private readonly IEntityAccessService<MediaData> _mediaDataAccessService;
    private readonly IDefaultDataService _defaultDataService;

    public PostTranslationFactory(
        IEntityAccessService<MediaData> mediaDataAccessService,
        IDefaultDataService defaultDataService)
    {
        _mediaDataAccessService = mediaDataAccessService;
        _defaultDataService = defaultDataService;
    }

    public async Task<PostTranslation> Create(PostDto dto)
    {
        var translation = new PostTranslation
        {
            Title = dto.Title,
            Summary = dto.Summary,
            Preview = await GetOrCreatePreview(dto),
            Video = dto.VideoUrl.IsNullOrEmpty() ? null : await CreateVideo(dto),
            LanguageId = await _defaultDataService.GetLanguageId(),
        };

        return translation;
    }

    private async Task<MediaData> GetOrCreatePreview(PostDto dto)
    {
        var existing = await GetExisingMediaData(dto.PreviewImageFilePath);
        
        return existing ?? new MediaData {Type = MediaDataType.Image, IsLocal = true, Url = dto.PreviewImageFilePath};
    }
    
    private async Task<MediaData> CreateVideo(PostDto dto)
    {
        var existing = await GetExisingMediaData(dto.VideoUrl);
        
        return existing ?? new MediaData {Type = MediaDataType.Video, IsLocal = false, Url = dto.VideoUrl};
    }

    private Task<MediaData> GetExisingMediaData(string url)
    {
        var query = new MediaDataQueryParams {Url = url};

        return _mediaDataAccessService.GetSingleOrDefault(query);
    }

    private class MediaDataQueryParams : BaseQueryParameters<MediaData>
    {
        public string Url { get; set; }

        protected override void AddFilters()
        {
            Filter(x => x.Url == Url);
        }
    }
}