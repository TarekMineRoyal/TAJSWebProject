using DataAccess.Entities;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TourAgencyDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TourAgencyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        // Async Methods
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = await _dbSet.AddAsync(entity);
            return addedEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(int id, TEntity newEntity)
        {
            _dbSet.Update(newEntity);
            return newEntity;
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

        public async Task<TEntity> AttachAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            return entity;
        }

        // Sync Methods
        public TEntity? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity>? GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity Add(TEntity entity)
        {
            var addedEntity = _dbSet.Add(entity);
            return addedEntity.Entity;
        }

        public TEntity Update(int id, TEntity newEntity)
        {
            _dbSet.Update(newEntity);
            return newEntity;
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

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        // Save Changes
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}