using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
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

            _tourAgencyDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            await _tourAgencyDbContext.SaveChangesAsync();

            return entity;
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

                _tourAgencyDbContext.SaveChanges();
            }

            return entity;
        }

        public async Task<TEntity?> RemoveAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);

                _tourAgencyDbContext.SaveChanges();
            }

            return entity;
        }

        public TEntity Update(int id, TEntity newEntity)
        {
            var oldEntity = _dbSet.Find(id);

            if (oldEntity != null)
            {
                oldEntity = newEntity;
            }

            _tourAgencyDbContext.SaveChanges();

            return newEntity;
        }

        public async Task<TEntity> UpdateAsync(int id, TEntity newEntity)
        {
            var oldEntity = await _dbSet.FindAsync(id);

            if (oldEntity != null)
            {
                oldEntity = newEntity;
            }

            _tourAgencyDbContext.SaveChanges();

            return newEntity;
        }
    }
}