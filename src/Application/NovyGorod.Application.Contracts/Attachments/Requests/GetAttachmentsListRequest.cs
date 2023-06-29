using MediatR;
using NovyGorod.Application.Contracts.Attachments.Dto;

namespace NovyGorod.Application.Contracts.Attachments.Requests;

public record GetAttachmentsListRequest : IRequest<AttachmentsListDto>
{
    public int PostBlockId { get; set; }

    public int? FirstAttachmentId { get; set; }
}