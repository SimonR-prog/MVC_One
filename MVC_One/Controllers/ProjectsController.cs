using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_One.Models;

namespace MVC_One.Controllers;

[Authorize]
public class ProjectsController(IStatusService statusService, IClientService clientService, IProjectService projectService, IUserService userService) : Controller
{
    private readonly IStatusService _statusService = statusService;
    private readonly IClientService _clientService = clientService;
    private readonly IProjectService _projectService = projectService;
    private readonly IUserService _userService = userService;


    public async Task<IActionResult> Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromForm] AddProjectViewModel model)
    {

    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm] UpdateProjectViewModel model)
    {

    }

}