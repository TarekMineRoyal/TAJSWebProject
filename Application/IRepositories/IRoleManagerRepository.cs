using System.Linq.Expressions;

namespace Application.IRepositories;

public interface IRoleManagerRepository<TRole> where TRole : class
{
    public Task<TRole?> GetByIdAsync(string id);

    public Task<IEnumerable<TRole>?> GetAllAsync();

    public Task<TRole> AddAsync(TRole entity);

    public Task<TRole?> UpdateAsync(string id, TRole newEntity);

    public Task<TRole?> RemoveAsync(string id);

    public Task<TRole> AttachAsync(TRole entity);

    public void SaveChanges();

    public Task SaveChangesAsync();

    public IEnumerable<TRole> AddRange(IEnumerable<TRole> entities);

    public Task<IEnumerable<TRole>> AddRangeAsync(IEnumerable<TRole> entities);

    public IEnumerable<TRole> DeleteRange(IEnumerable<TRole> entities);

    public Task<TRole?> GetFirstOrDefaultAsync(Expression<Func<TRole, bool>> predicate);

    public TRole? GetFirstOrDefault(Expression<Func<TRole, bool>> predicate);


    public TRole? GetById(string id);

    public IEnumerable<TRole>? GetAll();

    public TRole Add(TRole entity);

    public TRole? Update(string id, TRole entity);

    public TRole? Remove(string id);
}
