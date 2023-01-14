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

    [HttpGet("projects")]
    public Task<IActionResult> GetProjectsList(int page = 1)
    {
        return GetPostsList(PostType.Project, nameof(GetProjectsList), page);
    }

    [HttpGet("theatre")]
    public Task<IActionResult> GetTheatreList(int page = 1)
    {
        return GetPostsList(PostType.Theatre, nameof(GetTheatreList), page);
    }

    [HttpGet("school")]
    public Task<IActionResult> GetSchoolList(int page = 1)
    {
        return GetPostsList(PostType.School, nameof(GetSchoolList), page);
    }
    
    [HttpGet("festivals")]
    public Task<IActionResult> GetFestivalsList(int page = 1)
    {
        return GetPostsList(PostType.Festival, nameof(GetFestivalsList), page);
    }

    [HttpGet("post/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var request = new GetPostRequest { Id = id };
        var post = await _mediator.Send(request);

        var viewModel = new PostViewModel { Post = post};

        return PartialView("View", viewModel);
    }

    private async Task<IActionResult> GetPostsList(PostType type, string actionName, int pageIndex)
    {
        var request = new SearchPostsRequest {Type = type, PageSize = 6, PageIndex = --pageIndex};
        var result = await _mediator.Send(request);
        var viewModel = new PostsListViewModel
        {
            Type = request.Type, ControllerActionName = actionName, SearchResult = result,
        };

        return PartialView("ListView", viewModel);
    }
}