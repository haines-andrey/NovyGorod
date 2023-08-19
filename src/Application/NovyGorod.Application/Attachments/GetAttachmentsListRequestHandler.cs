using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using NovyGorod.Application.Common.Extensions;
using NovyGorod.Application.Common.RequestHandlers;
using NovyGorod.Application.Contracts.Attachments.Dto;
using NovyGorod.Application.Contracts.Attachments.Requests;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.Models.Attachments;
using NovyGorod.Domain.Services;

namespace NovyGorod.Application.Attachments;

internal class GetAttachmentsListRequestHandler : BaseRequestHandler<GetAttachmentsListRequest, AttachmentsListDto>
{
    private readonly IMapper _mapper;
    private readonly IReadOnlyRepository<Attachment> _repository;

    public GetAttachmentsListRequestHandler(
        IExecutionContextService executionContextService,
        IMapper mapper,
        IReadOnlyRepository<Attachment> repository)
        : base(executionContextService)
    {
        _mapper = mapper;
        _repository = repository;
    }

    protected override async Task<AttachmentsListDto> HandleInternal(
        GetAttachmentsListRequest request,
        CancellationToken cancellationToken)
    {
        var query = QueryBuilder<Attachment>
            .CreateWithFilter(
                attachment =>
                    attachment.BlockId == request.PostBlockId &&
                    attachment.Translations.Any(translation => translation.LanguageId == CurrentLanguageId))
            .Order(orderable => orderable.OrderBy(attachment => attachment.Index))
            .Build();

        var attachments = await _repository.GetCollection(query, cancellationToken);

        var attachmentsList = new AttachmentsListDto
        {
            Attachments = _mapper.MapWithTranslation<List<AttachmentDto>>(attachments, CurrentLanguageId),
        };

        return attachmentsList;
    }
}