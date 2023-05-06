using NovyGorod.DbSeeder.Dtos;
using NovyGorod.DbSeeder.Services;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class PostTranslationFactory : IEntityFactory<PostTranslation, PostDto>
{
    private readonly IEntityFactory<MediaData, MediaDataDto> _mediaDataFactory;
    private readonly IDefaultDataService _defaultDataService;

    public PostTranslationFactory(
        IEntityFactory<MediaData, MediaDataDto> mediaDataFactory,
        IDefaultDataService defaultDataService)
    {
        _mediaDataFactory = mediaDataFactory;
        _defaultDataService = defaultDataService;
    }

    public async Task<PostTranslation> Create(PostDto dto)
    {
        var translation = new PostTranslation
        {
            Title = dto.Title,
            Summary = dto.Summary,
            Preview = await _mediaDataFactory.Create(dto.PreviewImage),
            Video = !HasVideo(dto) ? null : await _mediaDataFactory.Create(dto.Video),
            LanguageId = await _defaultDataService.GetLanguageId(),
        };

        return translation;
    }

    private static bool HasVideo(PostDto dto) => dto.Video?.Url is not null;
}