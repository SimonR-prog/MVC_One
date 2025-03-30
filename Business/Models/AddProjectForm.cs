using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class AddProjectForm
{
    [DataType(DataType.Text)]
    [Display(Name = "Project Name", Prompt = "Enter a project name.")]
    [Required(ErrorMessage = "Required")]
    public string ProjectName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Client name", Prompt = "Enter a client name.")]
    [Required(ErrorMessage = "Required")]
    public string Client { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Description", Prompt = "Enter a description.")]
    public string? Description { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Start Date")]
    [Required(ErrorMessage = "Required")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "End Date")]
    [Required(ErrorMessage = "Required")]
    public DateTime EndDate { get; set; }

    [DataType(DataType.Currency)]
    [Display(Name = "Budget", Prompt = "Enter a budget.")]
    [Required(ErrorMessage = "Required")]
    public decimal Budget { get; set; }
}
