using NovyGorod.Application.Contracts.Attachments.Dto;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Contracts.Posts.Dto;

public record PostBlockDto : BaseEntityDto
{
    public string Title { get; init; }
    
    public string Text { get; init; }

    public virtual ICollection<AttachmentDto> Attachments { get; init; }
}