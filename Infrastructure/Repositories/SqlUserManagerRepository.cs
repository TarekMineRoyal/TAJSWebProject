using Application.IRepositories;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class SqlUserManagerRepository<TEntity> : IUserManagerRepository<TEntity> where TEntity : class
{
    private readonly IUserDbContext userDbContext;
    private readonly DbSet<TEntity> _dbSet;

    public SqlUserManagerRepository(IUserDbContext userDbContext)
    {
        this.userDbContext = userDbContext;
        _dbSet = userDbContext.Set<TEntity>();
    }

    public TEntity Add(TEntity entity)
    {
        _dbSet.Add(entity);

        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);

        return entity;
    }

    public Task<TEntity> AttachAsync(TEntity entity)
    {
        _dbSet.Attach(entity);

        return Task.FromResult(entity);
    }

    public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
    {
        _dbSet.AddRange(entities);

        return entities;
    }

    public IEnumerable<TEntity>? GetAll()
    {
        return _dbSet.ToList();
    }

    public async Task<IEnumerable<TEntity>?> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public TEntity? GetById(Guid id)
    {
        var stringId = id.ToString();

        return _dbSet.Find(stringId);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        var stringId = id.ToString();

        return await _dbSet.FindAsync(stringId);
    }

    public TEntity? Remove(Guid id)
    {
        var stringId = id.ToString();

        var entity = _dbSet.Find(stringId);

        if (entity != null)
        {
            _dbSet.Remove(entity);
        }

        return entity;
    }

    public async Task<TEntity?> RemoveAsync(Guid id)
    {
        var stringId = id.ToString();

        var entity = await _dbSet.FindAsync(stringId);

        if (entity != null)
        {
            _dbSet.Remove(entity);
        }

        return entity;
    }

    public void SaveChanges()
    {
        userDbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await userDbContext.SaveChangesAsync();
    }

    public TEntity? Update(Guid id, TEntity entity)
    {
        var stringId = id.ToString();

        // 1. Get existing entity
        var existingEntity = _dbSet.Find(stringId);

        if (existingEntity == null)
            return null;

        // 2. Get all properties EXCEPT the primary key
        var properties = userDbContext.Entry(existingEntity).Properties
            .Where(p => !p.Metadata.IsPrimaryKey());

        // 3. Update only non-key properties
        foreach (var property in properties)
        {
            var newValue = userDbContext.Entry(entity).Property(property.Metadata.Name).CurrentValue;
            property.CurrentValue = newValue;
        }

        return existingEntity;
    }

    public async Task<TEntity?> UpdateAsync(Guid id, TEntity entity)
    {
        var stringId = id.ToString();

        // 1. Get existing entity
        var existingEntity = await _dbSet.FindAsync(stringId);

        if (existingEntity == null)
            return null;

        // 2. Get all properties EXCEPT the primary key
        var properties = userDbContext.Entry(existingEntity).Properties
            .Where(p => !p.Metadata.IsPrimaryKey());

        // 3. Update only non-key properties
        foreach (var property in properties)
        {
            var newValue = userDbContext.Entry(entity).Property(property.Metadata.Name).CurrentValue;
            property.CurrentValue = newValue;
        }

        //_dbSet.Update(existingEntity);

        //existingEntity = entity;

        return existingEntity;

    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);

        return entities;
    }

    public IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
        return entities;
    }

    public TEntity? GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.FirstOrDefault(predicate);
    }

    public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }
}
