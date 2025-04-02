using Data.Context;
using Data.Entities;
using Data.Interfaces;
using Domain.Models;

namespace Data.Repositories;
public class CompanyRepository(DataContext context) : BaseRepository<CompanyEntity, Company>(context), ICompanyRepository
{
}
