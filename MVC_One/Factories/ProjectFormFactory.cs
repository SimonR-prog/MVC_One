using Domain.Models.Forms;
using MVC_One.Models;

namespace MVC_One.Factories;

public class ProjectFormFactory
{

    public static AddProjectFormData CreateProjectForm(AddProjectViewModel addViewModelData)
    {
        var newProjectFormData = new AddProjectFormData()
        {
            Image = addViewModelData.Image,
            ProjectName = addViewModelData.ProjectName,
            Description = addViewModelData.Description,
            StartDate = addViewModelData.StartData,
            EndDate = addViewModelData.EndDate,
            Budget = addViewModelData.Budget,
            ClientId = addViewModelData.ClientId,
            UserId = addViewModelData.UserId,
            StatusId = addViewModelData.StatusId
        };
        return newProjectFormData;
    }
    public static UpdateProjectFormData CreateProjectForm(UpdateProjectViewModel updateViewModelData)
    {
        var updatedProjectFormData = new UpdateProjectFormData()
        {
            Id = updateViewModelData.Id,
            Image = updateViewModelData.Image,
            ProjectName = updateViewModelData.ProjectName,
            Description = updateViewModelData.Description,
            StartDate = updateViewModelData.StartData,
            EndDate = updateViewModelData.EndDate,
            Budget = updateViewModelData.Budget,
            ClientId = updateViewModelData.ClientId,
            UserId = updateViewModelData.UserId,
            StatusId = updateViewModelData.StatusId
        };
        return updatedProjectFormData;
    }
}