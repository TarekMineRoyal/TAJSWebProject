using Application.DTOs.Car;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Domain.Entities.AppEntities;
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
        private readonly IGenericRepository<Booking> _bookingRepository;
        private readonly IGenericRepository<CarBooking> _carBookingRepository;
        private readonly IGenericRepository<TripBooking> _tripBookingRepository;
        private readonly IGenericRepository<TripPlanCar> _tripPlanCarRepository;
        private readonly IMapper _mapper;

        public CarService(
            IGenericRepository<Car> carRepository,
            IGenericRepository<Booking> bookingRepository,
            IGenericRepository<CarBooking> carBookingRepository,
            IGenericRepository<TripBooking> tripBookingRepository,
            IGenericRepository<TripPlanCar> tripPlanCarRepository,
            IMapper mapper)
        {
            _carRepository = carRepository;
            _bookingRepository = bookingRepository;
            _carBookingRepository = carBookingRepository;
            _tripBookingRepository = tripBookingRepository;
            _tripPlanCarRepository = tripPlanCarRepository;
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

        public async Task<IEnumerable<CarDTO>> GetAvailableCarsAsync(DateTime startDateTime, DateTime endDateTime)
        {
            // 1. Get unavailable car IDs from direct car bookings
            var overlappingCarBookingIds = (await _bookingRepository.WhereAsync(b =>
                b.BookingType == true &&
                b.StartDateTime < endDateTime && b.EndDateTime > startDateTime
            ))?.Select(b => b.Id).ToList() ?? new List<int>();

            var allCarBookings = await _carBookingRepository.GetAllAsync();
            var unavailableCarIdsFromCarBookings = allCarBookings
                .Where(cb => overlappingCarBookingIds.Contains(cb.BookingId))
                .Select(cb => cb.CarId);

            // 2. Get unavailable car IDs from trip bookings
            var overlappingTripBookingIds = (await _bookingRepository.WhereAsync(b =>
                b.BookingType == false &&
                b.StartDateTime < endDateTime && b.EndDateTime > startDateTime
            ))?.Select(b => b.Id).ToList() ?? new List<int>();

            var allTripBookings = await _tripBookingRepository.GetAllAsync();
            var relevantTripPlanIds = allTripBookings
                .Where(tb => tb.BookingId.HasValue && overlappingTripBookingIds.Contains(tb.BookingId.Value))
                .Select(tb => tb.TripPlanId)
                .ToList();

            var allTripPlanCars = await _tripPlanCarRepository.GetAllAsync();
            var unavailableCarIdsFromTripBookings = allTripPlanCars
                .Where(tpc => tpc.TripPlanId.HasValue && relevantTripPlanIds.Contains(tpc.TripPlanId.Value) && tpc.CarId.HasValue)
                .Select(tpc => tpc.CarId.Value);

            // 3. Combine the lists of unavailable car IDs
            var totalUnavailableCarIds = unavailableCarIdsFromCarBookings.Concat(unavailableCarIdsFromTripBookings).Distinct().ToList();

            // 4. Get all cars and filter out the unavailable ones
            var allCars = await _carRepository.GetAllAsync();
            var availableCars = allCars.Where(c => !totalUnavailableCarIds.Contains(c.Id));

            return _mapper.Map<IEnumerable<CarDTO>>(availableCars);
        }
    }
}