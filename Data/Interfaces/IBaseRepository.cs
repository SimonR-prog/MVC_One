using Domain.Interfaces;
using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IResponse> CreateAsync(TEntity entity);
    Task<IResponseContent<IEnumerable<TEntity>>> GetAllAsync();
    Task<IResponseContent<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IResponse> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IResponse> UpdateAsync(TEntity entity);
    Task<IResponse> DeleteAsync(TEntity entity);
}