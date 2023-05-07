using NovyGorod.Common.Extensions;
using NovyGorod.DbSeeder.Dtos;
using NovyGorod.Domain.Models.Attachments;
using NovyGorod.Domain.Models.Posts;

namespace NovyGorod.DbSeeder.EntityFactories;

internal class PostBlockFactory : ISequenceEntityFactory<PostBlock, PostBlockDto>
{
    private readonly IEntityFactory<PostBlockTranslation, PostBlockDto> _translationFactory;
    private readonly ISequenceEntityFactory<Attachment, AttachmentDto> _attachmentFactory;

    public PostBlockFactory(
        IEntityFactory<PostBlockTranslation, PostBlockDto> translationFactory,
        ISequenceEntityFactory<Attachment, AttachmentDto> attachmentFactory)
    {
        _translationFactory = translationFactory;
        _attachmentFactory = attachmentFactory;
    }

    public async Task<PostBlock> Create(PostBlockDto dto, int sequenceNumber)
    {
        var block = new PostBlock
        {
            Index = sequenceNumber,
            Translations = new[] {await CreateTranslation(dto)},
            Attachments = await CreateAttachments(dto).ToListAsync(),
        };

        return block;
    }
    
    private Task<PostBlockTranslation> CreateTranslation(PostBlockDto dto)
    {
        return _translationFactory.Create(dto);
    }

    private async IAsyncEnumerable<Attachment> CreateAttachments(PostBlockDto dto)
    {
        var sequenceNumber = 0;

        if (dto.Attachments.IsNullOrEmpty())
        {
            yield break;
        }

        foreach (var attachmentDto in dto.Attachments)
        {
            yield return await _attachmentFactory.Create(attachmentDto, sequenceNumber);
            sequenceNumber++;
        }
    }
}