using Microsoft.AspNetCore.Mvc;

namespace MVC_One.Controllers;

public class ProjectsController : Controller
{
    [Route("/")]
    [Route("projects")]
    public IActionResult Index()
    {
        return View();
    }



}
