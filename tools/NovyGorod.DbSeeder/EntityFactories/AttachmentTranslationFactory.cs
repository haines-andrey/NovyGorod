using NovyGorod.DbSeeder.Dtos;
using NovyGorod.DbSeeder.Services;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Attachments;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class AttachmentTranslationFactory : IEntityFactory<AttachmentTranslation, AttachmentDto>
{
    private readonly IEntityFactory<MediaData, MediaDataDto> _mediaDataFactory;
    private readonly IDefaultDataService _defaultDataService;

    public AttachmentTranslationFactory(
        IEntityFactory<MediaData, MediaDataDto> mediaDataFactory, 
        IDefaultDataService defaultDataService)
    {
        _mediaDataFactory = mediaDataFactory;
        _defaultDataService = defaultDataService;
    }

    public async Task<AttachmentTranslation> Create(AttachmentDto dto)
    {
        var translation = new AttachmentTranslation
        {
            LanguageId = await _defaultDataService.GetLanguageId(),
            SourceMedia = await _mediaDataFactory.Create(dto.SourceMediaData),
            Summary = dto.Summary,
        };

        return translation;
    }
}