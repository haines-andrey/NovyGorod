using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using NovyGorod.Application.Contracts.Media;
using NovyGorod.Application.Contracts.Media.Requests;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.ModelAccess.Queries.Builders;
using NovyGorod.Domain.Models;

namespace NovyGorod.Application.Media;

public class GetMediaDataRequestHandler : IRequestHandler<GetMediaDataRequest, FileStream>
{
    private readonly IConfiguration _configuration;
    private readonly IReadOnlyRepository<MediaData> _repository;

    public GetMediaDataRequestHandler(IConfiguration configuration, IReadOnlyRepository<MediaData> repository)
    {
        _configuration = configuration;
        _repository = repository;
    }

    public async Task<FileStream> Handle(GetMediaDataRequest request, CancellationToken cancellationToken)
    {
        var query = QueryBuilder<MediaData>.CreateWithFilter(Filters.MediaData.IdIs(request.Id)).Build();
        var mediaData = await _repository.GetSingleOrDefault(query, cancellationToken);

        if (mediaData is null || !mediaData.IsLocal)
        {
            return null;
        }

        var mediaDataDirectory = _configuration["MediaDataDirectory"];
        var path = Path.Combine(mediaDataDirectory, mediaData.Url);

        return File.OpenRead(path);
    }
}