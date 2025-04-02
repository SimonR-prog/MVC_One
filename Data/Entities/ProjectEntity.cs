using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? ImageUrl { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }

    public decimal? Budget { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;



    [ForeignKey(nameof(StatusName))]
    public int StatusId { get; set; }
    public StatusEntity StatusName { get; set; } = null!;


    [ForeignKey(nameof(Company))]
    public string CompanyId { get; set; } = null!;
    public CompanyEntity Company { get; set; } = null!;


    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
}

