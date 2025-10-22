using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bunker.Domain.Repositories;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();

    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> include, CancellationToken cancellationToken = default);

    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate);

    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default);

    Task<int> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
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

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public virtual async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        var entityList = entities.ToList();
        await _dbSet.AddRangeAsync(entityList, cancellationToken);
        return entityList;
    }

    public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _dbSet.Update(entity);
        return await Task.FromResult(entity);
    }

    public virtual async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        var entityList = entities.ToList();
        _dbSet.UpdateRange(entityList);
        return await Task.FromResult(entityList);
    }

    public virtual async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity == null)
            return false;

        _dbSet.Remove(entity);
        return true;
    }

    public virtual async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            return false;

        _dbSet.Remove(entity);
        return await Task.FromResult(true);
    }

    public virtual async Task<int> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
            return 0;

        var entityList = entities.ToList();
        _dbSet.RemoveRange(entityList);
        return await Task.FromResult(entityList.Count);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        // Materialize all entities of type T asynchronously
        var list = await _dbSet.ToListAsync(cancellationToken);
        return list;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> include, CancellationToken cancellationToken = default)
    {
        if (include == null)
            throw new ArgumentNullException(nameof(include));

        // Apply the include function to the query and materialize asynchronously
        var query = include(_dbSet);
        var list = await query.ToListAsync(cancellationToken);
        return list;
    }
}
