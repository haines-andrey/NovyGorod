using Microsoft.AspNetCore.Mvc;
using NovyGorodAsp.Models;

namespace NovyGorodAsp.Controllers;

public class ErrorController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new ErrorViewModel());
    }
}