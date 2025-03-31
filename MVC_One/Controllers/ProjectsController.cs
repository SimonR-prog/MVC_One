using Business.Models;
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

    //[HttpPost]
    //public async IActionResult Add(AddProjectForm form)
    //{
    //    if (!ModelState.IsValid) 
    //    {
    //        var errors = ModelState
    //            .Where(x => x.Value?.Errors.Count > 0)
    //            .ToDictionary(
    //                kvp => kvp.Key,
    //                kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
    //            );
    //        return BadRequest(new { errors });
    //    }

    //    var result = await _projectService.CreateAsyncProject(form);
        



    //    return Ok();
    //}

    //[HttpPut]
    //public IActionResult Update(UpdateProjectForm form)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        var errors = ModelState
    //            .Where(x => x.Value?.Errors.Count > 0)
    //            .ToDictionary(
    //                kvp => kvp.Key,
    //                kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
    //            );
    //        return BadRequest(new { errors });
    //    }

    //    //Save to db.

    //    return Ok();
    //}

    [HttpDelete]
    public IActionResult Delete()
    {
        return View();
    }

}
