using Data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Models.ResponseHandlers;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity, TModel>(DataContext context) : IBaseRepository<TEntity, TModel> where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<RepositoryResponse> CreateAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
            {
                return new RepositoryResponse()
                {
                    Success = false,
                    StatusCode = 400,
                    ErrorMessage = "Entity is null."
                };
            }
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResponse()
            {
                Success = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}"
            };
        }
    }

    public virtual async Task<RepositoryResponse> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var exists = await _dbSet.AnyAsync(predicate);

            if (!exists)
                return new RepositoryResponse()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Not found"
                };

            return new RepositoryResponse()
            {
                Success = true,
                StatusCode = 200,
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}"
            };
        }
    }

    public virtual async Task<RepositoryResponse<IEnumerable<TEntity>>> GetAllAsync(
            bool orderByDescending = false,
            Expression<Func<TEntity, object>>? sortBy = null,
            Expression<Func<TEntity, bool>>? where = null,
            params Expression<Func<TEntity, object>>[] includes)
    {
        try
        {
            IQueryable<TEntity> query = _dbSet;

            if (where != null)
                query = query.Where(where);

            if (includes != null && includes.Length != 0)
                foreach (var include in includes)
                    query = query.Include(include);

            if (sortBy != null)
                query = orderByDescending
                    ? query.OrderByDescending(sortBy)
                    : query.OrderBy(sortBy);

            var entities = await query.ToListAsync();
            if (entities.Count == 0)
                return new RepositoryResponse<IEnumerable<TEntity>>()
                {
                    Success = true,
                    StatusCode = 204,
                    Content = []
                };

            return new RepositoryResponse<IEnumerable<TEntity>>()
            {
                Success = true,
                StatusCode = 200,
                Content = entities
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse<IEnumerable<TEntity>>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
                Content = []
            };
        }
    }

    public virtual async Task<RepositoryResponse<IEnumerable<TSelect>>> GetAllAsync<TSelect>(
            Expression<Func<TEntity, TSelect>> selector,
            bool orderByDescending = false,
            Expression<Func<TEntity, object>>? sortBy = null,
            Expression<Func<TEntity, bool>>? where = null,
            params Expression<Func<TEntity, object>>[] includes)
    {
        try
        {
            IQueryable<TEntity> query = _dbSet;

            if (where != null)
                query = query.Where(where);

            if (includes != null && includes.Length != 0)
                foreach (var include in includes)
                    query = query.Include(include);

            if (sortBy != null)
                query = orderByDescending
                    ? query.OrderByDescending(sortBy)
                    : query.OrderBy(sortBy);

            var entities = await query.Select(selector).ToListAsync();
            if (entities.Count == 0)
                return new RepositoryResponse<IEnumerable<TSelect>>()
                {
                    Success = true,
                    StatusCode = 204,
                    Content = []
                };

            return new RepositoryResponse<IEnumerable<TSelect>>()
            {
                Success = true,
                StatusCode = 200,
                Content = entities
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse<IEnumerable<TSelect>>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
                Content = []
            };
        }
    }

    public virtual async Task<RepositoryResponse<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> where,
        params Expression<Func<TEntity, object>>[] includes)
    {
        try
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null && includes.Length != 0)
                foreach (var include in includes)
                    query = query.Include(include);

            var entity = await query.FirstOrDefaultAsync(where);

            if (entity == null)
                return new RepositoryResponse<TEntity>()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Not found"
                };

            return new RepositoryResponse<TEntity>()
            {
                Success = true,
                StatusCode = 200,
                Content = entity
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse<TEntity>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }

    public virtual async Task<RepositoryResponse> UpdateAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
                return new RepositoryResponse()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Not found"
                };

            var result = await ExistsAsync(e => e == entity);
            if (result.Success == false)
                return new RepositoryResponse()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Not found"
                };

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResponse() 
            { 
                Success = true, 
                StatusCode = 200 
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }
    public virtual async Task<RepositoryResponse> DeleteAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
                return new RepositoryResponse()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Not found"
                };

            var result = await ExistsAsync(e => e == entity);
            if (result.Success == false)
                return new RepositoryResponse()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Not found"
                };

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResponse()
            {
                Success = true,
                StatusCode = 200,
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResponse()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }
}
