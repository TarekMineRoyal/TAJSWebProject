using DataAccess.Entities;
using DataAccess.Repository.IRepository;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public class CarService
    {
        private readonly IGenericRepository<Car> _genericRepository;

        public CarService(IGenericRepository<Car> genericRepository)
        {
            _genericRepository = genericRepository;
        }


        public Task<CarDTO?> GetCarByIdAsync(int id)
        {
            return null;
        }

        public Task<IEnumerable<CarDTO>?> GetAllCarsAsync()
        {
            return null;
        }

        public Task<CreateCarDTO> AddCarAsync(CreateCarDTO car)
        {
            return null;
        }

        public Task<UpdateCarDTO> UpdateCarAsync(int id, UpdateCarDTO car)
        {
            return null;
        }

        public Task<CarDTO> DeleteCar(int id)
        {
            return null;
        }
    }
}
