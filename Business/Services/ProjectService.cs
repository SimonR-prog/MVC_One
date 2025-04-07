using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Domain.Models.Forms;
using Domain.Models.ResponseHandlers;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<ProjectResponse> AddProjectAsync(AddProjectFormData projectFormData)
    {
        // Take in a form => send to factory to get entity => send to repo to add and then return success if ok..





        02:39 i videon....
    }

    public async Task<ProjectResponse<IEnumerable<Project>>> GetAllProjectsAsync()
    {
        var projectEntities = await _projectRepository.GetAllAsync
            (
                orderByDescending: true,
                sortBy: s => s.Created,
                where: null,
                include => include.User,
                include => include.StatusName,
                include => include.ClientName
            );
        if (projectEntities == null)
        {
            return 
        }
        //send entitites to factory..


    }
    public async Task<ProjectResponse<Project>> GetProjectAsync(string id)
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
            return new ProjectResponse<Project>()
            {
                Success = false,
                StatusCode = 404,
                Content = null
            };
        }
        //Need to make entity => projectfactory
        return new ProjectResponse<Project>()
        {
            Success = true,
            StatusCode = 200,
            Content = project
        };

    }



    public async Task<ProjectResponse> UpdateProjectAsync()
    {
        //Takes in the (viewmodelform =>) updateform => factory to entity => updaterepo
    }
    public async Task<ProjectResponse> RemoveProjectAsync()
    {
        //Check if exists or null => deleterepo
    }
}
