using System.Linq.Expressions;

namespace Application.IRepositories;

public interface IRoleManagerRepository<TRole> where TRole : class
{
    public Task<TRole?> GetByIdAsync(Guid id);

    public Task<TRole?> GetByIdAsync(string id);

    public Task<IEnumerable<TRole>?> GetAllAsync();

    public Task<TRole> AddAsync(TRole entity);

    public Task<TRole?> UpdateAsync(Guid id, TRole newEntity);

    public Task<TRole?> RemoveAsync(Guid id);

    public Task<TRole> AttachAsync(TRole entity);

    public void SaveChanges();

    public Task SaveChangesAsync();

    public IEnumerable<TRole> AddRange(IEnumerable<TRole> entities);

    public Task<IEnumerable<TRole>> AddRangeAsync(IEnumerable<TRole> entities);

    public IEnumerable<TRole> DeleteRange(IEnumerable<TRole> entities);

    public Task<TRole?> GetFirstOrDefaultAsync(Expression<Func<TRole, bool>> predicate);

    public TRole? GetFirstOrDefault(Expression<Func<TRole, bool>> predicate);


    public TRole? GetById(Guid id);

    public TRole? GetById(string id);

    public IEnumerable<TRole>? GetAll();

    public TRole Add(TRole entity);

    public TRole? Update(Guid id, TRole entity);

    public TRole? Remove(Guid id);

    public IEnumerable<TRole>? Where(Expression<Func<TRole, bool>> predicate);

    public Task<IEnumerable<TRole>?> WhereAsync(Expression<Func<TRole, bool>> predicate);
}
