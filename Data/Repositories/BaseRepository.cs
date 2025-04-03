using Data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity, TModel>(DataContext context) : IBaseRepository<TEntity, TModel> where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<IResponse> CreateAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
            {
                return Response.NotFound("Entity in null.");
            }
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return Response.Ok();
        }
        catch (Exception ex)
        {
            return Response.Error($"An error occured: {ex.Message}");
        }
    }

    public virtual async Task<IResponse> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var exists = await _dbSet.AnyAsync(predicate);

            return exists ? Response.Ok() : Response.NotFound("Entity not found.");
        }
        catch (Exception ex)
        {
            return Response.Error($"An error occured: {ex.Message}");
        }
    }

    public virtual async Task<IResponseContent<IEnumerable<TEntity>>> GetAllAsync(
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
                return Response<IEnumerable<TEntity>>.Ok(new List<TEntity>());

            return Response<IEnumerable<TEntity>>.Ok(entities);
        }
        catch (Exception ex)
        {
            return Response<IEnumerable<TEntity>>.Error(new List<TEntity>(), $"An error occured: {ex.Message}");
        }
    }

    public virtual async Task<IResponseContent<IEnumerable<TSelect>>> GetAllAsync<TSelect>(
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
                return Response<IEnumerable<TSelect>>.Ok(new List<TSelect>());

            return Response<IEnumerable<TSelect>>.Ok(entities);
        }
        catch (Exception ex)
        {
            return Response<IEnumerable<TSelect>>.Error(new List<TSelect>(), $"An error occured: {ex.Message}");
        }
    }

    public virtual async Task<IResponseContent<TEntity>> GetAsync(
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
                return Response<TEntity>.NotFound(null, "Entity is null.");

            return Response<TEntity>.Ok(entity);
        }
        catch (Exception ex)
        {
            return Response<TEntity>.Error(null, $"An error occured: {ex.Message}");
        }
    }

    public virtual async Task<IResponse> UpdateAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
                return Response.NotFound("Entity is null.");

            var result = await ExistsAsync(e => e == entity);
            if (result.Success == false)
                return Response.NotFound("Entity not found");

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return Response.Ok();
        }
        catch (Exception ex)
        {
            return Response.Error($"An error occured: {ex.Message}");
        }
    }
    public virtual async Task<IResponse> DeleteAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
                return Response.NotFound("Entity is null.");

            var result = await ExistsAsync(e => e == entity);
            if (result.Success == false)
                return Response.NotFound("Entity not found");

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return Response.Ok();
        }
        catch (Exception ex)
        {
            return Response.Error($"An error occured: {ex.Message}");
        }
    }
}
