using AutoMapper;
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
        private readonly IGenericRepository<Car> _carRepository;
        private readonly IMapper _mapper;

        public CarService(IGenericRepository<Car> carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }


        public async Task<CarDTO?> GetCarByIdAsync(int id)
        {
            var car =  await _carRepository.GetByIdAsync(id);


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
