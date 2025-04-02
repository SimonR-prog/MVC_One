using Domain.Interfaces;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    //Added TModel to make it work..
    public interface IBaseRepository<TEntity, TModel> where TEntity : class
    {
        Task<IResponse> CreateAsync(TEntity entity);
        Task<IResponse> DeleteAsync(TEntity entity);
        Task<IResponse> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IResponseContent<IEnumerable<TEntity>>> GetAllAsync(bool orderByDescending = false, Expression<Func<TEntity, object>>? sortBy = null, Expression<Func<TEntity, bool>>? where = null, params Expression<Func<TEntity, object>>[] includes);
        Task<IResponseContent<IEnumerable<TSelect>>> GetAllAsync<TSelect>(Expression<Func<TEntity, TSelect>> selector, bool orderByDescending = false, Expression<Func<TEntity, object>>? sortBy = null, Expression<Func<TEntity, bool>>? where = null, params Expression<Func<TEntity, object>>[] includes);
        Task<IResponseContent<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes);
        Task<IResponse> UpdateAsync(TEntity entity);
    }
}