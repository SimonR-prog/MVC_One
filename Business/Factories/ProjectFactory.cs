using Data.Entities;
using Domain.Models.Forms;

namespace Business.Factories;

public class ProjectFactory
{
    public static ProjectEntity? Create(AddProjectFormData addProjectFormData) => new ProjectEntity
    {
        ProjectName = addProjectFormData.ProjectName,
        Description = addProjectFormData.Description,
        StartDate = addProjectFormData.StartDate,
        EndDate = addProjectFormData.EndDate,
        Budget = addProjectFormData.Budget,
        

        //Need ids from status/client..
    };
    public static ProjectEntity? Create(UpdateProjectFormData updateProjectFormData) => new ProjectEntity
    {
        Id = updateProjectFormData.Id,
        ProjectName = updateProjectFormData.ProjectName,
        Description = updateProjectFormData.Description,
        StartDate = updateProjectFormData.StartDate,
        EndDate = updateProjectFormData.EndDate,
        Budget = updateProjectFormData.Budget
    };








    public static Project? Create(ProjectEntity entity)
    {
        if (entity == null)
        {
            return null;
        }

        var project = new Project()
        {
            Id = entity.Id,
            ImageUrl = entity.ImageUrl,
            ProjectName = entity.ProjectName,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Budget = entity.Budget,
        };

        return project;
    }
}
