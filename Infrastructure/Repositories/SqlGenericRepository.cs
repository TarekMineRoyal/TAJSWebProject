using Application.IRepositories;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public TEntity Update(int id, TEntity newEntity)
        {
            var oldEntity = _dbSet.Find(id);

            if (oldEntity != null)
            {
                oldEntity = newEntity;
            }

            return newEntity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(int id, TEntity newEntity)
        {
            var oldEntity = await _dbSet.FindAsync(id);

            if (oldEntity != null)
            {
                oldEntity = newEntity;
            }

            return newEntity;
        }
    }
}