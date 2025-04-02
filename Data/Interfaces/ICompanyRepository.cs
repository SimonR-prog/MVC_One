using Data.Entities;
using Domain.Models;

namespace Data.Interfaces;

public interface ICompanyRepository : IBaseRepository<CompanyEntity, Company>
{

}
