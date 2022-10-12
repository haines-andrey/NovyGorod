using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.Models.Posts;
using NovyGorodAsp.Models.Posts;

namespace NovyGorodAsp.Controllers;

public class PostController : Controller
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<IActionResult> ViewList(PostType type)
    {
        var request = new SearchPostsRequest { Type = type, PageSize = 9 };
        var result = await _mediator.Send(request);

        var viewModel = new PostsViewModel {Type = type, Posts = result.Items};

        return PartialView(viewModel);
    }
    
    public async Task<IActionResult> View(int id)
    {
        var request = new GetPostRequest { Id = id };
        var post = await _mediator.Send(request);

        var viewModel = new PostViewModel { Post = post};

        return PartialView(viewModel);
    }
}