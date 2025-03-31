using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

[Index(nameof(CompanyName), IsUnique = true)]
public class CompanyEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CompanyName { get; set; } = null!;

    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
}

