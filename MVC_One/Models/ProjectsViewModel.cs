using Domain.Models;

namespace MVC_One.Models;

public class ProjectsViewModel
{
    public IEnumerable<Project> Projects { get; set; } = [];
    public AddProjectViewModel AddProjectFormData { get; set; } = new();
    public UpdateProjectViewModel UpdateProjectFormData { get; set; } = new();
}
