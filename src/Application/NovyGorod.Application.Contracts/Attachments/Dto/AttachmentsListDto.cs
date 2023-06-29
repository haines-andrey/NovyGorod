namespace NovyGorod.Application.Contracts.Attachments.Dto;

public record AttachmentsListDto
{
    public ICollection<AttachmentDto> Attachments { get; init; }
}