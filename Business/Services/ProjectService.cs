using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Domain.Models.Forms;
using Domain.Models.ResponseHandlers;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<ProjectResponse> AddProjectAsync(AddProjectFormData projectFormData)
    {
        try
        {
            var result = await _projectRepository.ExistsAsync(project => project.ProjectName == projectFormData.ProjectName);
            if (result.Success) 
            {
                return new ProjectResponse()
                {
                    Success = false,
                    StatusCode = 409,
                    ErrorMessage = "Project with this name already exists."
                };
            }

            projectFormData.StatusId = 1;
            var entityToAdd = ProjectFactory.Create(projectFormData);
            if (entityToAdd == null) 
            {
                return new ProjectResponse()
                {
                    Success = false,
                    StatusCode = 500,
                    ErrorMessage = "Something went wrong with creating the entity. Entity is null."
                };
            }

            var resultOfAdding = await _projectRepository.CreateAsync(entityToAdd);
            if (!resultOfAdding.Success)
            {
                return new ProjectResponse()
                {
                    Success = false,
                    StatusCode = 500,
                    ErrorMessage = "Something went wrong with adding the project."
                };
            }
            return new ProjectResponse()
            {
                Success = true,
                StatusCode = 200
            };
        }
        catch (Exception ex) 
        {
            return new ProjectResponse()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }

    public async Task<ProjectResponse<IEnumerable<Project>>> GetAllProjectsAsync()
    {
        try
        {
            var result = await _projectRepository.GetAllAsync
            (
                orderByDescending: true,
                sortBy: s => s.Created,
                where: null,
                include => include.User,
                include => include.Status,
                include => include.Client
            );

            var projectEntities = result.Content;
            if (projectEntities.IsNullOrEmpty())
            {
                return new ProjectResponse<IEnumerable<Project>>()
                {
                    Success = false,
                    StatusCode = 404,
                    Content = []
                };
            }

            var projects = projectEntities.Select(ProjectFactory.Create).ToList();
            return new ProjectResponse<IEnumerable<Project>>()
            {
                StatusCode = 200,
                Success = true,
                Content = projects
            };
        }
        catch (Exception ex) 
        {
            return new ProjectResponse<IEnumerable<Project>>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
                Content = []
            };
        }
    }
    public async Task<ProjectResponse<Project>> GetProjectAsync(string id)
    {
        try
        {
            var result = await _projectRepository.GetAsync
            (
                where: x => x.Id == id,
                include => include.User,
                include => include.Status,
                include => include.Client
            );
            var projectEntity = result.Content;

            if (projectEntity == null)
            {
                return new ProjectResponse<Project>()
                {
                    Success = false,
                    StatusCode = 404,
                    Content = null
                };
            }

            var project = ProjectFactory.Create(projectEntity);
            if (project == null)
                return new ProjectResponse<Project>()
                {
                    Success = false,
                    StatusCode = 404,
                    Content = null
                };
            return new ProjectResponse<Project>()
            {
                Success = true,
                StatusCode = 200,
                Content = project
            };
        }
        catch (Exception ex) 
        {
            return new ProjectResponse<Project>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }



    public async Task<ProjectResponse> UpdateProjectAsync(UpdateProjectFormData updatedProjectForm)
    {
        try
        {
            var updatedEntity = ProjectFactory.Create(updatedProjectForm);
            if (updatedEntity == null)
            {
                return new ProjectResponse<Project>()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "The returning updatedEntity is null."
                };
            }

            await _projectRepository.UpdateAsync(updatedEntity);
            return new ProjectResponse<Project>()
            {
                Success = true,
                StatusCode = 200,
            };
        }
        catch (Exception ex)
        {
            return new ProjectResponse<Project>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }
    public async Task<ProjectResponse> RemoveProjectAsync(string id)
    {
        try
        {
            var result = await _projectRepository.ExistsAsync(project => project.Id == id);
            if (result.Success == false)
            {
                return new ProjectResponse<Project>()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Project not found."
                };
            }

            var entityToRemove = await _projectRepository.GetAsync(project => project.Id == id);
            if (entityToRemove.Content == null)
            {
                return new ProjectResponse<Project>()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Project not found."
                };
            }

            var resultOfDelete = await _projectRepository.DeleteAsync(entityToRemove.Content);
            return new ProjectResponse<Project>()
            {
                Success = true,
                StatusCode = 200,
            };
        }
        catch (Exception ex)
        {
            return new ProjectResponse<Project>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }
}
