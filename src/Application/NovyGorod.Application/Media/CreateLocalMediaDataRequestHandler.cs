using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NovyGorod.Application.Contracts.Media;
using NovyGorod.Application.Contracts.Media.Requests;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Media;

public class CreateLocalMediaDataRequestHandler : IRequestHandler<CreateLocalMediaDataRequest, BaseEntityDto>
{
    private readonly IEntityModificationService<MediaData> _entityModificationService;
    private readonly ICommitter _committer;

    public CreateLocalMediaDataRequestHandler(
        IEntityModificationService<MediaData> entityModificationService,
        ICommitter committer)
    {
        _entityModificationService = entityModificationService;
        _committer = committer;
    }
    
    public async Task<BaseEntityDto> Handle(CreateLocalMediaDataRequest request, CancellationToken cancellationToken)
    {
        var guid = Guid.NewGuid() + request.FileExtension;

        await using var file = new FileStream(guid, FileMode.Create);
        await request.Stream.CopyToAsync(file, cancellationToken);

        var entity = new MediaData {Url = guid, Type = request.Type, IsLocal = true};
        entity = await _entityModificationService.Add(entity);
        await _committer.Commit();

        return new BaseEntityDto { Id = entity.Id };
    }
}