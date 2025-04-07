using Domain.Models.Forms;
using MVC_One.Models;

namespace MVC_One.Factories;

public class ProjectFormFactory
{

    public static AddProjectFormData CreateProjectForm(AddProjectViewModel addViewModelData)
    {
        var newProjectFormData = new AddProjectFormData()
        {

        };
        return newProjectFormData;
    }
    public static UpdateProjectFormData CreateProjectForm(UpdateProjectViewModel updateViewModelData)
    {
        var updatedProjectFormData = new UpdateProjectFormData()
        {

        };
        return updatedProjectFormData;
    }
}
