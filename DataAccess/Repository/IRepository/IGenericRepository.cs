using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>?> GetAllAsync();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(int id, TEntity newEntity);

        Task<TEntity?> RemoveAsync(int id);



        TEntity? GetById(int id);

        IEnumerable<TEntity>? GetAll();

        TEntity Add(TEntity entity);

        TEntity Update(int id, TEntity newEntity);

        TEntity? Remove(int id);

    }
}
