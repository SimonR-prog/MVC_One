using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class UpdateProjectForm
{
    public string Id { get; set; } = null!;
    public string ProjectName { get; set; } = null!;
    public string Client {  get; set; } = null!;
    public string ProjectDescription { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Budget { get; set; }
}
