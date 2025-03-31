using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int Id { get; set; }

    public string? ImageUrl { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public decimal? Budget { get; set; }



    [ForeignKey(nameof(Status))]
    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;



    [ForeignKey(nameof(Company))]
    public int CompanyId { get; set; }
    public CompanyEntity Company { get; set; } = null!;
}

public class StatusEntity
{
    public int Id { get; set; }
    public string Status { get; set; } = null!;
}
public class CompanyEntity
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
}

public class UserEntity : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string 
}

