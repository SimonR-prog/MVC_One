using Microsoft.AspNetCore.Mvc;
using MVC_One.Models;

namespace MVC_One.Controllers;

public class AuthController : Controller
{
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel registerModel)
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginForm form)
    {
        return View();
    }



}
