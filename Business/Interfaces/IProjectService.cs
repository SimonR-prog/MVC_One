using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Forms;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<IResponse> AddProjectAsync(AddProjectFormData projectFormData);
        Task<IResponseContent<IEnumerable<Project>>> GetAllProjectsAsync();
        Task<IResponseContent<Project>> GetProjectAsync(string id);
        Task<IResponse> RemoveProjectAsync();
        Task<IResponse> UpdateProjectAsync();
    }
}