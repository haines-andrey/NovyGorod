using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using NovyGorod.Application.Contracts.Media;
using NovyGorod.Application.Contracts.Media.Requests;
using NovyGorod.Domain.Models.Common;

namespace NovyGorodAsp.Controllers;

[Route("[controller]")]
public class MediaDataController : Controller
{
    private readonly IMediator _mediator;

    public MediaDataController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    [ResponseCache(Duration = 30 * 60, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> View(int id)
    {
        var request = new GetMediaDataRequest {Id = id};
        var stream = await _mediator.Send(request);

        new FileExtensionContentTypeProvider().TryGetContentType(stream.Name, out var contentType);

        return File(stream, contentType ?? string.Empty);
    }

    [HttpPost]
    public async Task<BaseEntityDto> Upload(IFormFile file)
    {
        var stream = file.OpenReadStream();
        var extension = Path.GetExtension(file.FileName);

        var request = new CreateLocalMediaDataRequest
        {
            Stream = stream, FileExtension = extension,
        };

        var dto = await _mediator.Send(request);

        return dto;
    }
}