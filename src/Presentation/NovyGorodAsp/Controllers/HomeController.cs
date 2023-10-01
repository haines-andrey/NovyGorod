using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.Models.Posts;
using NovyGorod.Domain.Services;
using NovyGorodAsp.Models.Home;

namespace NovyGorodAsp.Controllers;

public class HomeController : Controller
{
    private readonly IExecutionContextService _executionContextService;
    private readonly IMediator _mediator;

    public HomeController(
        IExecutionContextService executionContextService,
        IMediator mediator)
    {
        _executionContextService = executionContextService;
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var currentLanguageId = await _executionContextService.GetCurrentLanguageId();
        var projects = await _mediator.Send(new SearchPostsRequest
        {
            Type = PostType.Project, PageSize = 3, LanguageId = currentLanguageId
        });
        var theatre = await _mediator.Send(new SearchPostsRequest
        {
            Type = PostType.Theatre, PageSize = 3, LanguageId = currentLanguageId,
        });
        var school = await _mediator.Send(new SearchPostsRequest
        {
            Type = PostType.School, PageSize = 3, LanguageId = currentLanguageId,
        });

        var viewModel = new IndexViewModel
        {
            LastProjects = projects.Items,
            LastTheatrePosts = theatre.Items,
            LastSchoolPosts = school.Items,
        };

        return View(viewModel);
    }

    [HttpGet("contacts")]
    public IActionResult ContactsView()
    {
        return View(new ContactsViewModel());
    }
}