using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NovyGorod.Application.Attachments.Queries;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Common.RequestHandlers;
using NovyGorod.Application.Contracts.Attachments.Dto;
using NovyGorod.Application.Contracts.Attachments.Requests;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.Models.Attachments;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Attachments;

internal class GetAttachmentsListRequestHandler : BaseRequestHandler<GetAttachmentsListRequest, AttachmentsListDto>
{
    private readonly IMapper _mapper;
    private readonly IEntityAccessService<Attachment> _attachmentAccessService;

    public GetAttachmentsListRequestHandler(
        IExecutionContextService executionContextService,
        IMapper mapper,
        IEntityAccessService<Attachment> attachmentAccessService)
        : base(executionContextService)
    {
        _mapper = mapper;
        _attachmentAccessService = attachmentAccessService;
    }

    protected override async Task<AttachmentsListDto> HandleInternal(
        GetAttachmentsListRequest request,
        CancellationToken cancellationToken)
    {
        var query = new AttachmentQueryParameters {PostBlockId = request.PostBlockId, LanguageId = CurrentLanguageId};
        var attachments = await _attachmentAccessService.GetCollection(query);

        var attachmentsList = new AttachmentsListDto
        {
            Attachments = _mapper.MapWithTranslation<List<AttachmentDto>>(attachments, CurrentLanguageId),
        };

        return attachmentsList;
    }
}