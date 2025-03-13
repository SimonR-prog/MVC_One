using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected DataContext()
    {
    }

    public virtual DbSet<UserEntity> Users { get; set; }
    public virtual DbSet<ProjectEntity> Projects { get; set; }
    public virtual DbSet<CompanyEntity> Companys { get; set; }
    public virtual DbSet<StatusEntity> Statuses { get; set; }

}


//Db string.
//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="C:\Nackademin\Asp .NET 1\One\MVC_One\Data\Data\DataBase.mdf";Integrated Security=True;Connect Timeout=30