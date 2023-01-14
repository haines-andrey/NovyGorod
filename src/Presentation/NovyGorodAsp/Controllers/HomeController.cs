using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NovyGorod.Application.Contracts.Posts.Requests;
using NovyGorod.Domain.Models.Posts;
using NovyGorodAsp.Models;
using NovyGorodAsp.Models.Home;

namespace NovyGorodAsp.Controllers;

public class HomeController : Controller
{
    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var projects = await _mediator.Send(new SearchPostsRequest { Type = PostType.Project, PageSize = 3 });
        var theatre = await _mediator.Send(new SearchPostsRequest { Type = PostType.Theatre, PageSize = 3 });
        var school = await _mediator.Send(new SearchPostsRequest { Type = PostType.School, PageSize = 3 });

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
    
    // public IActionResult Translate(string culture, string returnUrl)
    // {
    //     return Ok();
    // }
}