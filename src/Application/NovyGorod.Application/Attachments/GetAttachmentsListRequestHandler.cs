using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Contracts.Attachments.Dto;
using NovyGorod.Application.Contracts.Attachments.Requests;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.Models.Attachments;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Attachments;

internal class GetAttachmentsListRequestHandler : IRequestHandler<GetAttachmentsListRequest, AttachmentsListDto>
{
    private readonly IExecutionContextAccessor _executionContextAccessor;
    private readonly IMapper _mapper;
    private readonly IReadOnlyRepository<Attachment> _repository;

    public GetAttachmentsListRequestHandler(
        IExecutionContextAccessor executionContextAccessor,
        IMapper mapper,
        IReadOnlyRepository<Attachment> repository)
    {
        _executionContextAccessor = executionContextAccessor;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<AttachmentsListDto> Handle(
        GetAttachmentsListRequest request,
        CancellationToken cancellationToken)
    {
        var currentLanguageId = await _executionContextAccessor.GetCurrentLanguageId();

        var queryFilter = Filters.Attachment.BlockIdIs(request.PostBlockId) &
                          Filters.Attachment.IsTranslatedInto(currentLanguageId); 
        var query = QueryBuilder<Attachment>.CreateNew()
            .Where(queryFilter)
            .Order(orderable => orderable.OrderBy(attachment => attachment.Index))
            .Build();

        var attachments = await _repository.GetCollection(query, cancellationToken);

        var attachmentsList = new AttachmentsListDto
        {
            Attachments = _mapper.MapWithTranslation<List<AttachmentDto>>(attachments, currentLanguageId),
        };

        return attachmentsList;
    }
}