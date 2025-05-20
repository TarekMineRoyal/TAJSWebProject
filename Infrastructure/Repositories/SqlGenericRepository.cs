using Application.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Repositories
{
    public class SqlGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly TourAgencyDbContext _tourAgencyDbContext;
        protected readonly DbSet<TEntity> _dbSet;


        public SqlGenericRepository(TourAgencyDbContext tourAgencyDbContext)
        {
            _tourAgencyDbContext = tourAgencyDbContext;
            _dbSet = tourAgencyDbContext.Set<TEntity>();
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

        public TEntity? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public TEntity? Remove(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
            }

            return entity;
        }

        public async Task<TEntity?> RemoveAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
            }

            return entity;
        }

        public void SaveChanges()
        {
            _tourAgencyDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _tourAgencyDbContext.SaveChangesAsync();
        }

        public TEntity? Update(int id, TEntity entity)
        {
            // 1. Get existing entity
            var existingEntity = _dbSet.Find(id);

            if (existingEntity == null)
                return null;

            // 2. Get all properties EXCEPT the primary key
            var properties = _tourAgencyDbContext.Entry(existingEntity).Properties
                .Where(p => !p.Metadata.IsPrimaryKey());

            // 3. Update only non-key properties
            foreach (var property in properties)
            {
                var newValue = _tourAgencyDbContext.Entry(entity).Property(property.Metadata.Name).CurrentValue;
                property.CurrentValue = newValue;
            }

            return existingEntity;
        }

        public async Task<TEntity?> UpdateAsync(int id, TEntity entity)
        {
            // 1. Get existing entity
            var existingEntity = await _dbSet.FindAsync(id);

            if (existingEntity == null)
                return null;

            // 2. Get all properties EXCEPT the primary key
            var properties = _tourAgencyDbContext.Entry(existingEntity).Properties
                .Where(p => !p.Metadata.IsPrimaryKey());

            // 3. Update only non-key properties
            foreach (var property in properties)
            {
                var newValue = _tourAgencyDbContext.Entry(entity).Property(property.Metadata.Name).CurrentValue;
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
}