using Microsoft.AspNetCore.Mvc;

namespace MVC_One.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
