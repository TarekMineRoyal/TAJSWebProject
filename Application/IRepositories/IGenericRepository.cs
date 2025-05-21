using System.Linq.Expressions;

namespace Application.IRepositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    public Task<TEntity?> GetByIdAsync(int id);

    public Task<IEnumerable<TEntity>?> GetAllAsync();

    public Task<TEntity> AddAsync(TEntity entity);

    public Task<TEntity?> UpdateAsync(int id, TEntity newEntity);

    public Task<TEntity?> RemoveAsync(int id);

    public Task<TEntity> AttachAsync(TEntity entity);

    public void SaveChanges();

    public Task SaveChangesAsync();

    public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

    public Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

    public IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities);

    public Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    public TEntity? GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);


    public TEntity? GetById(int id);

    public IEnumerable<TEntity>? GetAll();

    public TEntity Add(TEntity entity);

    public TEntity? Update(int id, TEntity entity);

    public TEntity? Remove(int id);

    
}
