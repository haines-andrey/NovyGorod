using NovyGorod.DbSeeder.Dtos;
using NovyGorod.DbSeeder.Services;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class PostTranslationFactory : IEntityFactory<PostTranslation, PostDto>
{
    private readonly IDefaultDataService _defaultDataService;

    public PostTranslationFactory(
        IDefaultDataService defaultDataService)
    {
        _defaultDataService = defaultDataService;
    }

    public async Task<PostTranslation> Create(PostDto dto)
    {
        var translation = new PostTranslation
        {
            Title = dto.Title,
            Summary = dto.Summary,
            Preview = CreatePreview(dto),
            Video = CreateVideo(dto),
            LanguageId = await _defaultDataService.GetLanguageId(),
        };

        return translation;
    }

    private MediaData CreatePreview(PostDto dto)
    {
        return new MediaData {Type = MediaDataType.Image, IsLocal = true, Url = dto.PreviewImageFilePath};
    }
    
    private MediaData CreateVideo(PostDto dto)
    {
        return new MediaData {Type = MediaDataType.Video, IsLocal = false, Url = dto.VideoUrl};
    }
}