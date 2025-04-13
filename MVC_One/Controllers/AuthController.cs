using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using MVC_One.Factories;
using MVC_One.Models;
using System.Security.Claims;

namespace MVC_One.Controllers;

public class AuthController(IAuthService authService, IUserService userService) : Controller
{
    private readonly IAuthService _authService = authService;
    private readonly IUserService _userService = userService;

    [Route("auth/register")]
    public IActionResult Register(string returnUrl = "~/")
    {
        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "";

        return View();
    }

    [HttpPost]
    [Route("auth/register")]
    public async Task<IActionResult> Register(RegisterViewModel registerModel, string returnUrl = "~/")
    {
        if (!ModelState.IsValid) 
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.ErrorMessage = "";
            return View(registerModel);
        }

        var signUpFormData = SignUpFactory.Create(registerModel);
        var authResult = await _authService.SignUpAsync(signUpFormData);

        if (authResult.Success) 
        { 
            return LocalRedirect(returnUrl);
        }

        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = authResult.ErrorMessage;
        return View(registerModel);
    }

    [Route("auth/login")]
    public IActionResult Login(string returnUrl = "~/")
    {
        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "";
        return View();
    }

    [Route("auth/login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginModel, string returnUrl = "~/")
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.ErrorMessage = "Error when trying to log in.";
            return View(loginModel);
        }

        var signInFormData = SignInFactory.Create(loginModel);
        var authResult = await _authService.SignInAsync(signInFormData);

        if (authResult.Success)
        {
            return LocalRedirect(returnUrl);
        }

        ViewBag.ReturnUrl = returnUrl;
        ViewBag.ErrorMessage = "Error when trying to log in.";
        return View(loginModel);
    }

    [Route("auth/logout")]
    public async Task<IActionResult> LogOut()
    {
        await _authService.SignOutAsync();
        return LocalRedirect("~/");
    }


}
