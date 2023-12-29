using NovyGorod.Application.Contracts.Common.Dto;
using NovyGorod.Application.Contracts.Media.Dto;

namespace NovyGorod.Application.Contracts.Attachments.Dto;

public record AttachmentDto : BaseModelDto
{
    public string Summary { get; init; }

    public MediaDataDto PreviewMedia { get; init; }

    public MediaDataDto SourceMedia { get; init; }
}