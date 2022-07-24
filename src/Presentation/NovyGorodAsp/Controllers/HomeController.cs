using Microsoft.AspNetCore.Mvc;
using NovyGorodAsp.Models;

namespace NovyGorodAsp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(new HomeViewModel());
    }
}