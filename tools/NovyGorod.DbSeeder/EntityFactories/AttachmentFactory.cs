using NovyGorod.DbSeeder.Dtos;
using NovyGorod.Domain.Models.Attachments;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class AttachmentFactory : ISequenceEntityFactory<Attachment, AttachmentDto>
{
    private readonly IEntityFactory<AttachmentTranslation, AttachmentDto> _translationFactory;

    public AttachmentFactory(
        IEntityFactory<AttachmentTranslation, AttachmentDto> translationFactory)
    {
        _translationFactory = translationFactory;
    }

    public async Task<Attachment> Create(AttachmentDto dto, int sequenceNumber)
    {
        var attachment = new Attachment
        {
            Index = sequenceNumber,
            Translations = new[] {await CreateTranslation(dto)},
        };

        return attachment;
    }

    private Task<AttachmentTranslation> CreateTranslation(AttachmentDto dto)
    {
        return _translationFactory.Create(dto);
    }
}