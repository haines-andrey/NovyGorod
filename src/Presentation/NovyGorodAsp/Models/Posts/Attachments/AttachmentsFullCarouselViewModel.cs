using System.Collections.Generic;
using NovyGorod.Application.Contracts.Attachments.Dto;

namespace NovyGorodAsp.Models.Posts.Attachments;

public class AttachmentsFullCarouselViewModel
{
    public AttachmentsListDto AttachmentsList { get; set; }

    public int? FirstAttachmentId { get; set; }
}