using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NovyGorod.Application.Contracts.Posts;
using NovyGorod.Application.Contracts.Posts.Requests;

namespace NovyGorodAsp.Controllers;

public class PostController : Controller
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public IActionResult ViewList()
    {
        return PartialView();
    }
    
    public async Task<IActionResult> View(int id)
    {
        var request = new GetPostRequest { Id = id };
        var dto = await _mediator.Send(request);

        return PartialView(dto);
    }
}