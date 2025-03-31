using Data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _db = context.Set<TEntity>();

    public virtual async Task<IResponse> CreateAsync(TEntity entity)
    {
        try
        {
            if (entity == null)
            {
                return Response.Error("Entity in null.");
            }
            await _db.AddAsync(entity);
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
            var exists = await _db.AnyAsync(predicate);

            return exists ? Response.Ok() : Response.NotFound("Entity not found.");
        }
        catch (Exception ex)
        {
            return Response.Error($"An error occured: {ex.Message}");
        }
    }

    public virtual async Task<IResponseContent<IEnumerable<TEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _db.ToListAsync();
            if (entities.Count == 0)
                return Response<IEnumerable<TEntity>>.Ok(new List<TEntity>());

            return Response<IEnumerable<TEntity>>.Ok(entities);
        }
        catch (Exception ex)
        {
            return Response<IEnumerable<TEntity>>.Error(new List<TEntity>(), $"An error occured: {ex.Message}");
        }
    }

    public virtual async Task<IResponseContent<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = await _db.FirstOrDefaultAsync(predicate);
            if (entity == null)
                return Response<TEntity>.Error(null, "Entity is null.");

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
                return Response<TEntity>.Error(null, "Entity is null.");

            var result = await ExistsAsync(e => e == entity);
            if (result.Success == false)
                return Response.NotFound("Entity not found");

            _db.Update(entity);
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
                return Response.Error("Entity is null.");

            var result = await ExistsAsync(e => e == entity);
            if (result.Success == false)
                return Response.NotFound("Entity not found");

            _db.Remove(entity);
            await _context.SaveChangesAsync();

            return Response.Ok();
        }
        catch (Exception ex)
        {
            return Response.Error($"An error occured: {ex.Message}");
        }
    }
}
