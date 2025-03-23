using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Entities;


[Index(nameof(Email), IsUnique = true)]
public class UserEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string HashKey { get; set; } = null!;

    public int CompanyId { get; set; }
    public CompanyEntity Company { get; set; } = null!;

    public ICollection<UserProjectEntity> UserProjects { get; set; } = [];
}

public class ProjectEntity
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "date")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;

    public ICollection<UserProjectEntity> UserProjects { get; set; } = [];
}

public class CompanyEntity
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}

public class StatusEntity
{
    public int Id { get; set; }
    public string StatusType {  get; set; } = null!;
    public ICollection<ProjectEntity> Projects { get; set; } = [];
}

public class UserProjectEntity
{
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public int ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = null!;
}