using Business.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_One.Factories;
using MVC_One.Models;

namespace MVC_One.Controllers;

[Authorize]
public class ProjectsController(IStatusService statusService, IClientService clientService, IProjectService projectService, IUserService userService) : Controller
{
    private readonly IStatusService _statusService = statusService;
    private readonly IClientService _clientService = clientService;
    private readonly IProjectService _projectService = projectService;
    private readonly IUserService _userService = userService;

    [Route("/Projects")]
    public async Task<IActionResult> Index()
    {
        var viewModel = new ProjectsViewModel()
        {
            Projects = await SetProjectsAsync(),
            AddProjectFormData = new AddProjectViewModel
            {
                Clients = await SetClientSelectListItemsAsync(),
                Users = await SetUserSelectListItemsAsync(),
            },
            UpdateProjectFormData = new UpdateProjectViewModel
            {
                Clients = await SetClientSelectListItemsAsync(),
                Users = await SetUserSelectListItemsAsync(),
                Statuses = await SetStatusSelectListItemsAsync()
            }
        };

        return View(viewModel);
    }

    [Route("/Projects/Create")]
    [HttpPost]
    public async Task<IActionResult> Create(AddProjectViewModel addProjectViewModelData)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value!.Errors.Any())
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return Json(new { success = false, errors });
        }

        var projectFormData = ProjectFormFactory.CreateProjectForm(addProjectViewModelData);

        var result = await _projectService.AddProjectAsync(projectFormData);
        if (result != null)
            return Json(new { success = true });

        return Json(new { success = false });
    }

    [Route("/Projects/Update")]
    [HttpPost]
    public async Task<IActionResult> Update([FromForm] UpdateProjectViewModel updateProjectViewModelData)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState
                .Where(x => x.Value!.Errors.Any())
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return Json(new { success = false, errors });
        }

        var updatedProjectFormData = ProjectFormFactory.CreateProjectForm(updateProjectViewModelData);

        var result = await _projectService.UpdateProjectAsync(updatedProjectFormData);
        if (result != null)
            return Json(new { success = true });

        return Json(new { success = false });
    }

    [Route("/Projects/Delete")]
    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {

        var result = await _projectService.RemoveProjectAsync(id);
        if (result.Success == false)
            return Json(new { success = false });

        return Json(new { success = true });
    }


    private async Task<IEnumerable<Project>> SetProjectsAsync()
    {
        var result = await _projectService.GetAllProjectsAsync();
        var projects = result.Content ?? [];
        projects = projects.OrderByDescending(x => x.Created);
        return projects;
    }

    private async Task<IEnumerable<SelectListItem>> SetClientSelectListItemsAsync()
    {
        var result = await _clientService.GetAllClientAsync();
        var clients = result.Content ?? [];
        clients = clients.OrderBy(x => x.ClientName);

        var selectListItems = clients.Select(client => new SelectListItem
        {
            Value = client.Id,
            Text = client.ClientName
        });

        return selectListItems;
    }
    private async Task<IEnumerable<SelectListItem>> SetUserSelectListItemsAsync()
    {
        var result = await _userService.GetAllUsersAsync();
        var users = result.Content;
        users = users.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

        var selectListItems = users.Select(user => new SelectListItem
        {
            Value = user.Id,
            Text = $"{user.FirstName} {user.LastName}"
        });

        return selectListItems;
    }

    private async Task<IEnumerable<SelectListItem>> SetStatusSelectListItemsAsync()
    {
        var result = await _statusService.GetAllStatusAsync();
        var statuses = result.Content;
        statuses = statuses.OrderBy(x => x.Id);

        var selectListItems = statuses.Select(status => new SelectListItem
        {
            Value = status.Id.ToString(),
            Text = status.StatusName
        });

        return selectListItems;
    }
}
