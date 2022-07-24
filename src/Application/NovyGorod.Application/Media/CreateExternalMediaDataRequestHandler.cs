using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NovyGorod.Application.Contracts.Media;
using NovyGorod.Application.Contracts.Media.Requests;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Media;

public class CreateExternalMediaDataRequestHandler : IRequestHandler<CreateExternalMediaDataRequest, BaseEntityDto>
{
    private readonly IMapper _mapper;
    private readonly IEntityModificationService<MediaData> _entityModificationService;

    public CreateExternalMediaDataRequestHandler(
        IMapper mapper,
        IEntityModificationService<MediaData> entityModificationService)
    {
        _mapper = mapper;
        _entityModificationService = entityModificationService;
    }

    public async Task<BaseEntityDto> Handle(CreateExternalMediaDataRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<MediaData>(request);
        entity = await _entityModificationService.Add(entity);

        return new BaseEntityDto {Id = entity.Id};
    }
}