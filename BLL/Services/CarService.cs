using AutoMapper;
using BLL.IServices;
using DataAccess.Entities;
using DataAccess.Repository.IRepository;
using DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CarService : ICarService
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
            var car = await _carRepository.GetByIdAsync(id);
            return _mapper.Map<CarDTO>(car); // Use AutoMapper
        }

        public async Task<IEnumerable<CarDTO>?> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarDTO>>(cars); // Use AutoMapper
        }

        public async Task<CreateCarDTO> AddCarAsync(CreateCarDTO carAddDto)
        {
            var car = _mapper.Map<Car>(carAddDto); // Map DTO to entity

            // Avoid manually setting Id (AutoMapper should handle this)
            var addedCar = await _carRepository.AddAsync(car);
            _carRepository.SaveChanges();

            return _mapper.Map<CreateCarDTO>(addedCar); // Map entity back to DTO
        }

        public async Task<CarDTO?> UpdateCarAsync(int id, UpdateCarDTO carUpdateDto)
        {
            var existingCar = await _carRepository.GetByIdAsync(id);
            if (existingCar == null) return null;

            // Map updates to the existing entity
            _mapper.Map(carUpdateDto, existingCar);

            await _carRepository.UpdateAsync(id, existingCar);
            _carRepository.SaveChanges();

            return _mapper.Map<CarDTO>(existingCar); // Return mapped DTO
        }

        public async Task<CarDTO> DeleteCar(int id)
        {
            var car = await _carRepository.RemoveAsync(id);
            _carRepository.SaveChanges();
            return _mapper.Map<CarDTO>(car); // Use AutoMapper
        }
    }
}