using Business.Models;
using Data.Entities;
using Domain.Models;

namespace Business.Factories;

public class ProjectFactory
{
    public static ProjectEntity? Create(AddProjectForm addProjectForm) => new ProjectEntity
    {
        ProjectName = addProjectForm.ProjectName,
        Description = addProjectForm.Description,
        StartDate = addProjectForm.StartDate,
        EndDate = addProjectForm.EndDate,
        Budget = addProjectForm.Budget,
        

        //Need ids from status/client..
    };
    public static ProjectEntity? Create(UpdateProjectForm updateProjectForm) => new ProjectEntity
    {
        Id = updateProjectForm.Id,
        ProjectName = updateProjectForm.ProjectName,
        Description = updateProjectForm.Description,
        StartDate = updateProjectForm.StartDate,
        EndDate = updateProjectForm.EndDate,
        Budget = updateProjectForm.Budget
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
