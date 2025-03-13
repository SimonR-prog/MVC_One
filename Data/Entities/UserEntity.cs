using Microsoft.EntityFrameworkCore;
namespace Data.Entities;


[Index(nameof(Email), IsUnique = true)]
public class UserEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PassKey { get; set; } = null!;

    public int CompanyId { get; set; }
    public CompanyEntity Company { get; set; } = null!;

    public ICollection<ProjectEntity> Projects { get; set; } = [];
}

public class CompanyEntity
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public ICollection<UserEntity> Users { get; set; } = [];
}


public class ProjectEntity
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime EndDate { get; set; }
    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;
}

public class StatusEntity
{
    public int Id { get; set; }
    public string StatusType {  get; set; } = null!;
}