using Data.Entities;
using Domain.Models;
using Domain.Models.Forms;

namespace Business.Factories;

public class ProjectFactory
{
    public static Project Create(ProjectEntity entity)
    {
        if (entity == null) { return null; }
        var project = new Project()
        {
            Id = entity.Id,
            ImageUrl = entity.ImageUrl,
            ProjectName = entity.ProjectName,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Budget = entity.Budget,

            Client = new Client()
            {
                Id = entity.Client.Id,
                ClientName = entity.Client.ClientName
            },
            Status = new Status()
            {
                Id = entity.Status.Id,
                StatusName = entity.Status.StatusName
            },
            User = new User()
            {
                Id = entity.User.Id,
                FirstName = entity.User.FirstName,
                LastName = entity.User.LastName,
                Email = entity.User.Email,
                PhoneNumber = entity.User.PhoneNumber
            }
        };
        return project;
    }

    public static ProjectEntity Create(AddProjectFormData addFormData)
    {
        var newProjectEntity = new ProjectEntity()
        {
            ImageUrl = addFormData.Image,
            ProjectName = addFormData.ProjectName,
            Description = addFormData.Description,
            StartDate = addFormData.StartDate,
            EndDate = addFormData.EndDate,
            Budget = addFormData.Budget,
            ClientId = addFormData.ClientId,
            UserId = addFormData.UserId,
            StatusId = addFormData.StatusId
        };
        return newProjectEntity;
    }

    public static ProjectEntity Create(UpdateProjectFormData updateFormData)
    {
        var updatedProjectEntity = new ProjectEntity()
        {
            Id = updateFormData.Id,
            ProjectName = updateFormData.ProjectName,
            Description = updateFormData.Description,
            StartDate = updateFormData.StartDate,
            EndDate = updateFormData.EndDate,
            Budget = updateFormData.Budget,
            ClientId = updateFormData.ClientId,
            UserId = updateFormData.UserId,
            StatusId = updateFormData.StatusId
        };
        return updatedProjectEntity;
    }
}
