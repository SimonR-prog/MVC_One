using Microsoft.AspNetCore.Mvc;

namespace MVC_One.Controllers;

public class AuthController : Controller
{
    public IActionResult Register()
    {
        return View();
    }

    //[HttpPost]
    //public IActionResult Register(RegisterForm form)
    //{
    //    return View();
    //}

    public IActionResult Login()
    {
        return View();
    }

//    [HttpPost]
//    public IActionResult Login(LoginForm form)
//    {
//        return View();
//    }



}
