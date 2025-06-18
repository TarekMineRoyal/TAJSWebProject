using Application.DTOs.Car;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Domain.Entities.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IGenericRepository<Booking> _bookingRepository;
        private readonly IGenericRepository<CarBooking> _carBookingRepository;
        private readonly IGenericRepository<TripBooking> _tripBookingRepository;
        private readonly IGenericRepository<TripPlanCar> _tripPlanCarRepository;
        private readonly IMapper _mapper;

        public CarService(
            ICarRepository carRepository,
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

        public async Task<PaginatedCarResponseDTO> GetAllCarsAsync(CarQueryParameters queryParameters)
        {
            var (cars, totalCount) = await _carRepository.GetFilteredCars(queryParameters);

            var carDtos = _mapper.Map<IEnumerable<CarDTO>>(cars);

            return new PaginatedCarResponseDTO
            {
                Cars = carDtos,
                CurrentPage = queryParameters.PageNumber,
                PageSize = queryParameters.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParameters.PageSize)
            };
        }

        public async Task<PaginatedCarResponseDTO> GetAvailableCarsAsync(DateTime startDateTime, DateTime endDateTime, CarQueryParameters queryParameters)
        {
            // Get unavailable car IDs from direct car bookings
            var overlappingCarBookingIds = (await _bookingRepository.WhereAsync(b =>
                b.BookingType == true &&
                b.StartDateTime < endDateTime && b.EndDateTime > startDateTime
            ))?.Select(b => b.Id).ToList() ?? new List<int>();

            var allCarBookings = await _carBookingRepository.GetAllAsync();
            var unavailableCarIdsFromCarBookings = allCarBookings
                .Where(cb => overlappingCarBookingIds.Contains(cb.BookingId))
                .Select(cb => cb.CarId);

            // Get unavailable car IDs from trip bookings
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

            // Combine the lists of unavailable car IDs
            var totalUnavailableCarIds = unavailableCarIdsFromCarBookings.Concat(unavailableCarIdsFromTripBookings).Distinct().ToList();

            // Pass the excluded IDs to the repository to perform the final filtered and paginated query
            var (cars, totalCount) = await _carRepository.GetFilteredCars(queryParameters, totalUnavailableCarIds);

            var carDtos = _mapper.Map<IEnumerable<CarDTO>>(cars);

            return new PaginatedCarResponseDTO
            {
                Cars = carDtos,
                CurrentPage = queryParameters.PageNumber,
                PageSize = queryParameters.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)queryParameters.PageSize)
            };
        }

        public async Task<CarDTO?> GetCarByIdAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            var carDto = _mapper.Map<CarDTO>(car);
            return carDto;
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

            await _carRepository.SaveChangesAsync();

            return _mapper.Map<CarDTO>(car);
        }

        public async Task<CarDTO> DeleteCar(int id)
        {
            var car = await _carRepository.RemoveAsync(id);
            await _carRepository.SaveChangesAsync();
            return _mapper.Map<CarDTO>(car);
        }
    }
}
