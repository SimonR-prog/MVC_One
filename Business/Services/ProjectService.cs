using Business.Interfaces;
using Data.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Forms;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<IResponse> AddProjectAsync(AddProjectFormData projectFormData)
    {
        // Take in a form => send to factory to get entity => send to repo to add and then return success if ok..



        02:39 i videon....
    }

    public async Task<IResponseContent<IEnumerable<Project>>> GetAllProjectsAsync()
    {
        var projects = await _projectRepository.GetAllAsync
            (
                orderByDescending: true,
                sortBy: s => s.Created,
                where: null,
                include => include.User,
                include => include.StatusName,
                include => include.ClientName
            );
        if (projects == null)
        {
            return Response<IEnumerable<Project>>.NotFound(new List<Project>(), "No projects found.");
        }


    }
    public async Task<IResponseContent<Project>> GetProjectAsync(string id)
    {
        var result = await _projectRepository.GetAsync
            (
                where: x => x.Id == id,
                include => include.User,
                include => include.StatusName,
                include => include.ClientName
            );
        var project = result.Content;

        if (project == null)
        {
            return Response<Project>.NotFound(new Project, "Project not found.");
        }

        return Response<Project>.Ok(project);

    }



    public async Task<IResponse> UpdateProjectAsync()
    {

    }
    public async Task<IResponse> RemoveProjectAsync()
    {

    }
}
