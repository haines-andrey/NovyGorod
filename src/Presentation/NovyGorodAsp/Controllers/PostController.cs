using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.Models.Posts;
using NovyGorod.Domain.Services;
using NovyGorodAsp.Models.Posts;

namespace NovyGorodAsp.Controllers;

public class PostController : Controller
{
    private readonly IExecutionContextAccessor _executionContextAccessor;
    private readonly IMediator _mediator;

    public PostController(
        IExecutionContextAccessor executionContextAccessor,
        IMediator mediator)
    {
        _executionContextAccessor = executionContextAccessor;
        _mediator = mediator;
    }

    [HttpGet("projects")]
    public Task<IActionResult> ViewProjectsList(int page = 1)
    {
        return ViewPostsList(PostType.Project, nameof(ViewProjectsList), page);
    }

    [HttpGet("theatre")]
    public Task<IActionResult> ViewTheatreList(int page = 1)
    {
        return ViewPostsList(PostType.Theatre, nameof(ViewTheatreList), page);
    }

    [HttpGet("school")]
    public Task<IActionResult> ViewSchoolList(int page = 1)
    {
        return ViewPostsList(PostType.School, nameof(ViewSchoolList), page);
    }
    
    [HttpGet("festivals")]
    public Task<IActionResult> ViewFestivalsList(int page = 1)
    {
        return ViewPostsList(PostType.Festival, nameof(ViewFestivalsList), page);
    }

    [HttpGet("post/{id}")]
    public async Task<IActionResult> View(int id)
    {
        var currentLanguageId = await _executionContextAccessor.GetCurrentLanguageId();
        var request = new GetPostRequest { Id = id, LanguageId = currentLanguageId };
        var post = await _mediator.Send(request);

        var viewModel = new PostViewModel { Post = post};

        return PartialView("View", viewModel);
    }

    private async Task<IActionResult> ViewPostsList(PostType type, string actionName, int pageIndex)
    {
        var currentLanguageId = await _executionContextAccessor.GetCurrentLanguageId();
        var request = new PaginatePostsRequest
        {
            Type = type, LanguageId = currentLanguageId, PageSize = 6, PageIndex = --pageIndex,
        };
        var result = await _mediator.Send(request);
        var viewModel = new PostsListViewModel
        {
            Type = request.Type, ControllerActionName = actionName, ModelsPaginationResult = result,
        };

        return PartialView("ListView", viewModel);
    }
}