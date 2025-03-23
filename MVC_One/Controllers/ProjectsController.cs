using Microsoft.AspNetCore.Mvc;

namespace MVC_One.Controllers;

public class ProjectsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
