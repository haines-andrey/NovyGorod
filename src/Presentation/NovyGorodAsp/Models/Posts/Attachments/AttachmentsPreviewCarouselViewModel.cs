using System.Collections.Generic;
using NovyGorod.Application.Contracts.Attachments.Dto;

namespace NovyGorodAsp.Models.Posts.Attachments;

public class AttachmentsPreviewCarouselViewModel
{
    public int PostBlockId { get; set; }
    
    public ICollection<AttachmentDto> Attachments { get; set; }
}