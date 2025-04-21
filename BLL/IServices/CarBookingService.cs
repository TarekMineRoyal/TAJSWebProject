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
    public class CarBookingService
    {
        IGenericRepository<Car> _carRepository;
        private readonly CarService _carService;
        private readonly IMapper _mapper;
        IGenericRepository<CarBooking> _carBookingRepository;
        public CarBookingService(IGenericRepository<Car> carRepository, IGenericRepository<CarBooking> carBookingRepository, 
            CarService carService, IMapper mapper)
        {
            _carBookingRepository = carBookingRepository;
            _carRepository = carRepository;
            _carService  = carService;
            _mapper = mapper;
        }

        public async Task<CreateCarBookingDTO> AddCarBooking(CarBookingDTO carBookingDTO)
        {
            var carBooking = _mapper.Map<CarBooking>(carBookingDTO);
            await _carBookingRepository.AddAsync(carBooking);
            await _carBookingRepository.SaveChangesAsync();
        }

    }
}
