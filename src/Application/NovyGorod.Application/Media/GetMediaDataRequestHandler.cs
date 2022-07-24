using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using NovyGorod.Application.Contracts.Media;
using NovyGorod.Application.Contracts.Media.Requests;
using NovyGorod.Domain.EntityAccess;
using NovyGorod.Domain.EntityAccess.Queries;
using NovyGorod.Domain.Models;

namespace NovyGorod.Application.Media;

public class GetMediaDataRequestHandler : IRequestHandler<GetMediaDataRequest, FileStream>
{
    private readonly IConfiguration _configuration;
    private readonly IEntityAccessService<MediaData> _entityAccessService;

    public GetMediaDataRequestHandler(IConfiguration configuration, IEntityAccessService<MediaData> entityAccessService)
    {
        _configuration = configuration;
        _entityAccessService = entityAccessService;
    }

    public async Task<FileStream> Handle(GetMediaDataRequest request, CancellationToken cancellationToken)
    {
        var query = new BaseEntityQueryParameters<MediaData> { Id = request.Id };
        var mediaData = await _entityAccessService.GetSingleOrDefault(query);

        if (mediaData is null || !mediaData.IsLocal)
        {
            return null;
        }

        var mediaDataDirectory = _configuration["MediaDataDirectory"];
        var path = Path.Combine(mediaDataDirectory, mediaData.Url);

        return File.OpenRead(path);
    }
}