using Domain.Models;
using Domain.Models.Forms;
using Domain.Models.ResponseHandlers;


namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectResponse> AddProjectAsync(AddProjectFormData projectFormData);
        Task<ProjectResponse<IEnumerable<Project>>> GetAllProjectsAsync();
        Task<ProjectResponse<Project>> GetProjectAsync(string id);
        Task<ProjectResponse> RemoveProjectAsync(string id);
        Task<ProjectResponse> UpdateProjectAsync(UpdateProjectFormData updatedProjectForm);
    }
}