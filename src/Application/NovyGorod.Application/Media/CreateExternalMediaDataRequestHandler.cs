using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NovyGorod.Application.Contracts.Media.Requests;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Media;

public class CreateExternalMediaDataRequestHandler : IRequestHandler<CreateExternalMediaDataRequest, BaseModelDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository<MediaData> _repository;
    private readonly ICommitter _committer;

    public CreateExternalMediaDataRequestHandler(
        IMapper mapper,
        IRepository<MediaData> repository,
        ICommitter committer)
    {
        _mapper = mapper;
        _repository = repository;
        _committer = committer;
    }

    public async Task<BaseModelDto> Handle(CreateExternalMediaDataRequest request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<MediaData>(request);
        model = await _repository.Add(model, cancellationToken);
        await _committer.Commit(cancellationToken);

        return new BaseModelDto {Id = model.Id};
    }
}