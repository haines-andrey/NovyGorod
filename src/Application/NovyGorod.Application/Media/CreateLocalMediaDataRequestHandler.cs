using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using NovyGorod.Application.Contracts.Media;
using NovyGorod.Application.Contracts.Media.Requests;
using NovyGorod.Domain.ModelAccess;
using NovyGorod.Domain.Models;
using NovyGorod.Domain.Models.Common;

namespace NovyGorod.Application.Media;

public class CreateLocalMediaDataRequestHandler : IRequestHandler<CreateLocalMediaDataRequest, BaseModelDto>
{
    private readonly IRepository<MediaData> _repository;
    private readonly IConfiguration _configuration;
    private readonly ICommitter _committer;

    public CreateLocalMediaDataRequestHandler(
        IRepository<MediaData> repository,
        IConfiguration configuration,
        ICommitter committer)
    {
        _repository = repository;
        _configuration = configuration;
        _committer = committer;
    }
    
    public async Task<BaseModelDto> Handle(CreateLocalMediaDataRequest request, CancellationToken cancellationToken)
    {
        var fileName = GetFileName(request);
        var fileDirectory = GetFileDirectory(fileName);
        var path = Path.Combine(fileDirectory, fileName);
        await CreateFile(path, request);

        var entity = await CreateAndSaveEntity(fileName, request);

        return new BaseModelDto { Id = entity.Id };
    }

    private string GetFileName(CreateLocalMediaDataRequest request)
    {
        var date = DateTime.Today;
        var year = date.ToString("yyyy");
        var month = date.ToString("MM");
        var name = Guid.NewGuid();
        var extension = request.FileExtension;

        return Path.Combine(year, month, name + extension);
    }

    private async Task CreateFile(string filePath, CreateLocalMediaDataRequest request)
    {
        await using var file = new FileStream(filePath, FileMode.Create);
        await request.Stream.CopyToAsync(file);
    }

    private string GetFileDirectory(string fileName)
    {
        var rootDirectory = _configuration["MediaDataDirectory"];
        var fileDirectory = Path.GetDirectoryName(fileName) ?? string.Empty;
        var path = Path.Combine(rootDirectory, fileDirectory);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        return rootDirectory;
    }

    private async Task<MediaData> CreateAndSaveEntity(string fileName, CreateLocalMediaDataRequest request)
    {
        var entity = new MediaData { Url = fileName, Type = request.Type, IsLocal = true };
        entity = await _repository.Add(entity);
        await _committer.Commit();

        return entity;
    }
}