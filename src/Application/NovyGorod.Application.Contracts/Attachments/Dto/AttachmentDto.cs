using NovyGorod.Application.Contracts.Media;
using NovyGorod.Application.Contracts.Media.Dto;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Contracts.Attachments.Dto;

public record AttachmentDto : BaseEntityDto
{
    public string Summary { get; init; }

    public MediaDataDto Media { get; init; }
}