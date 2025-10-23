using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using System.Linq.Expressions;

namespace Bunker.UnitTest.Fakes;

public class FakeAsyncQueryable<T> : IQueryable<T>, IAsyncEnumerable<T>
{
    private readonly IQueryable<T> _queryable;

    public FakeAsyncQueryable(IQueryable<T> queryable)
    {
        _queryable = queryable;
    }

    public Type ElementType => _queryable.ElementType;
    public Expression Expression => _queryable.Expression;
    public IQueryProvider Provider => new FakeAsyncQueryProvider(_queryable.Provider);

    public IEnumerator<T> GetEnumerator() => _queryable.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _queryable.GetEnumerator();

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new FakeAsyncEnumerator<T>(_queryable.GetEnumerator());
    }
}

public class FakeAsyncQueryProvider : IAsyncQueryProvider
{
    private readonly IQueryProvider _inner;

    public FakeAsyncQueryProvider(IQueryProvider inner)
    {
        _inner = inner;
    }

    public IQueryable CreateQuery(Expression expression)
    {
        return _inner.CreateQuery(expression);
    }

    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        return new FakeAsyncQueryable<TElement>(_inner.CreateQuery<TElement>(expression));
    }

    public object Execute(Expression expression)
    {
        return _inner.Execute(expression);
    }

    public TResult Execute<TResult>(Expression expression)
    {
        return _inner.Execute<TResult>(expression)!;
    }

    public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default)
    {
        // For async operations, we need to handle them synchronously in the fake
        if (typeof(TResult).IsGenericType && typeof(TResult).GetGenericTypeDefinition() == typeof(Task<>))
        {
            var resultType = typeof(TResult).GetGenericArguments()[0];
            var executeMethod = _inner.GetType().GetMethod("Execute", new[] { typeof(Expression) });
            var result = executeMethod?.Invoke(_inner, new object[] { expression });

            if (result != null)
            {
                var task = Task.FromResult(result);
                return (TResult)(object)task;
            }
        }

        return _inner.Execute<TResult>(expression)!;
    }
}

public class FakeAsyncEnumerator<T> : IAsyncEnumerator<T>
{
    private readonly IEnumerator<T> _enumerator;

    public FakeAsyncEnumerator(IEnumerator<T> enumerator)
    {
        _enumerator = enumerator;
    }

    public T Current => _enumerator.Current;

    public ValueTask DisposeAsync()
    {
        _enumerator.Dispose();
        return ValueTask.CompletedTask;
    }

    public ValueTask<bool> MoveNextAsync()
    {
        return ValueTask.FromResult(_enumerator.MoveNext());
    }
}

public class FakeRepository<T> : IRepository<T> where T : class
{
    private readonly IList<T> _entities;
    private int _nextId = 1;

    protected FakeRepository(IList<T> collection)
    {
        _entities = collection;
    }

    public IQueryable<T> GetAll()
    {
        return new FakeAsyncQueryable<T>(_entities.AsQueryable());
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(1, cancellationToken); // Simulate async operation
        return _entities.AsEnumerable();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> include, CancellationToken cancellationToken = default)
    {
        if (include == null)
            throw new ArgumentNullException(nameof(include));

        await Task.Delay(1, cancellationToken); // Simulate async operation
        var query = include(_entities.AsQueryable());
        return query.AsEnumerable();
    }

    public Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        // Try to find entity by Id property using reflection
        var entity = _entities.FirstOrDefault(e => GetEntityId(e) == id);
        return Task.FromResult(entity);
    }

    public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate)
    {
        return new FakeAsyncQueryable<T>(_entities.AsQueryable().Where(predicate));
    }

    public Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var entity = _entities.AsQueryable().FirstOrDefault(predicate);
        return Task.FromResult(entity);
    }

    public Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        // Set Id if the entity has an Id property
        SetEntityId(entity, _nextId++);

        _entities.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        var entityList = entities.ToList();
        foreach (var entity in entityList)
        {
            SetEntityId(entity, _nextId++);
            _entities.Add(entity);
        }
        return Task.FromResult(entityList.AsEnumerable());
    }

    public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var id = GetEntityId(entity);
        var existingEntity = _entities.FirstOrDefault(e => GetEntityId(e) == id);

        if (existingEntity != null)
        {
            var index = _entities.IndexOf(existingEntity);
            _entities[index] = entity;
        }
        else
        {
            _entities.Add(entity);
        }

        return Task.FromResult(entity);
    }

    public Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        var entityList = entities.ToList();
        foreach (var entity in entityList)
        {
            var id = GetEntityId(entity);
            var existingEntity = _entities.FirstOrDefault(e => GetEntityId(e) == id);

            if (existingEntity != null)
            {
                var index = _entities.IndexOf(existingEntity);
                _entities[index] = entity;
            }
            else
            {
                _entities.Add(entity);
            }
        }

        return Task.FromResult(entityList.AsEnumerable());
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = _entities.FirstOrDefault(e => GetEntityId(e) == id);
        if (entity == null)
            return Task.FromResult(false);

        _entities.Remove(entity);
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            return Task.FromResult(false);

        var removed = _entities.Remove(entity);
        return Task.FromResult(removed);
    }

    public Task<int> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
            return Task.FromResult(0);

        var entityList = entities.ToList();
        var count = 0;
        foreach (var entity in entityList)
        {
            if (_entities.Remove(entity))
                count++;
        }

        return Task.FromResult(count);
    }

    // Helper methods to work with entity IDs using reflection
    private int GetEntityId(T entity)
    {
        var idProperty = typeof(T).GetProperty("Id");
        if (idProperty != null && idProperty.PropertyType == typeof(int))
        {
            return (int)idProperty.GetValue(entity)!;
        }
        return 0;
    }

    private void SetEntityId(T entity, int id)
    {
        var idProperty = typeof(T).GetProperty("Id");
        if (idProperty != null && idProperty.PropertyType == typeof(int) && idProperty.CanWrite)
        {
            idProperty.SetValue(entity, id);
        }
    }

}
