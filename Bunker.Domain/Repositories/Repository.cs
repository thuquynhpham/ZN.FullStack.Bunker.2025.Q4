using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bunker.Domain.Repositories;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();

    Task<T?> GetByIdAsync(int id);

    IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate);

    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    Task<T> AddAsync(T entity);

    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

    Task<T> UpdateAsync(T entity);

    Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);

    Task<bool> DeleteAsync(int id);

    Task<bool> DeleteAsync(T entity);

    Task<int> DeleteRangeAsync(IEnumerable<T> entities);
}

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }

    public virtual IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public virtual async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _dbSet.AddAsync(entity);
        return entity;
    }

    public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        var entityList = entities.ToList();
        await _dbSet.AddRangeAsync(entityList);
        return entityList;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _dbSet.Update(entity);
        return await Task.FromResult(entity);
    }

    public virtual async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        var entityList = entities.ToList();
        _dbSet.UpdateRange(entityList);
        return await Task.FromResult(entityList);
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            return false;

        _dbSet.Remove(entity);
        return true;
    }

    public virtual async Task<bool> DeleteAsync(T entity)
    {
        if (entity == null)
            return false;

        _dbSet.Remove(entity);
        return await Task.FromResult(true);
    }

    public virtual async Task<int> DeleteRangeAsync(IEnumerable<T> entities)
    {
        if (entities == null)
            return 0;

        var entityList = entities.ToList();
        _dbSet.RemoveRange(entityList);
        return await Task.FromResult(entityList.Count);
    }
}
