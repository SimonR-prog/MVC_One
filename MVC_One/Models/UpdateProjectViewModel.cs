using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_One.Models;

public class UpdateProjectViewModel
{
    public IEnumerable<SelectListItem> Clients { get; set; } = [];
    public IEnumerable<SelectListItem> Users { get; set; } = [];
    public IEnumerable<SelectListItem> Statuses { get; set; } = [];
}
