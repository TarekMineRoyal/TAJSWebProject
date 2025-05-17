using Application.DTOs;
using Application.DTOs.Car;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
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

            var carDto = _mapper.Map<CarDTO>(car);

            return carDto;
        }

        public async Task<IEnumerable<CarDTO>?> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            var carsDto = new List<CarDTO>();

            if (cars is not null)
            {
                foreach (Car car in cars)
                {
                    carsDto.Add(_mapper.Map<CarDTO>(car));
                }
            }

            return carsDto;
        }

        public async Task<CreateCarDTO> AddCarAsync(CreateCarDTO carAddDto)
        {
            var car = _mapper.Map<Car>(carAddDto);

            car = await _carRepository.AddAsync(car);
            await _carRepository.SaveChangesAsync();

            return _mapper.Map<CreateCarDTO>(car);
        }

        public async Task<CarDTO?> UpdateCarAsync(int id, UpdateCarDTO carUpdateDto)
        {
            var car = await _carRepository.GetByIdAsync(id);

            if (car is null)
                return null;

            var mappedCar = _mapper.Map<Car>(carUpdateDto);

            mappedCar.Id = car.Id;

            car = await _carRepository.UpdateAsync(id, mappedCar);

            _carRepository.SaveChanges();

            return _mapper.Map<CarDTO>(car);
        }

        public async Task<CarDTO> DeleteCar(int id)
        {
            var carDto = await _carRepository.RemoveAsync(id);

            _carRepository.SaveChanges();

            return _mapper.Map<CarDTO>(carDto);
        }
    }
}
