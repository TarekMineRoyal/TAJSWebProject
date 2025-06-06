﻿using System.Linq.Expressions;

namespace Application.IRepositories;

public interface IUserManagerRepository<TEntity> where TEntity : class
{
    public Task<TEntity?> GetByIdAsync(Guid id);

    public Task<TEntity?> GetByIdAsync(string id);

    public Task<IEnumerable<TEntity>?> GetAllAsync();

    public Task<TEntity> AddAsync(TEntity entity);

    public Task<TEntity?> UpdateAsync(Guid id, TEntity newEntity);

    public Task<TEntity?> RemoveAsync(Guid id);

    public Task<TEntity> AttachAsync(TEntity entity);

    public void SaveChanges();

    public Task SaveChangesAsync();

    public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

    public Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

    public IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities);

    public Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    public TEntity? GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);


    public TEntity? GetById(Guid id);

    public TEntity? GetById(string id);

    public IEnumerable<TEntity>? GetAll();

    public TEntity Add(TEntity entity);

    public TEntity? Update(Guid id, TEntity entity);

    public TEntity? Remove(Guid id);
}