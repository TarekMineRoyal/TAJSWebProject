using Application.DTOs.CarBooking;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.AppEntities;

namespace Application.Services
{
    public class CarBookingService : ICarBookingService
    {
        private readonly IGenericRepository<CarBooking> _carBookingRepo;
        private readonly IGenericRepository<Car> _carRepo;
        private readonly IGenericRepository<Booking> _bookingRepo;
        private readonly IMapper _mapper;

        public CarBookingService(IGenericRepository<CarBooking> carBookingRepo,
            IGenericRepository<Car> carRepo,
            IGenericRepository<Booking> bookingRepo, IMapper mapper)
        {
            _carBookingRepo = carBookingRepo;
            _bookingRepo = bookingRepo;
            _carRepo = carRepo;
            _mapper = mapper;
        }

        public async Task<AddCarBookingResponse?> GetCarBookingByIdAsync(int id)
        {
            var booking = await _carBookingRepo.GetByIdAsync(id);
            return booking != null ? _mapper.Map<AddCarBookingResponse>(booking) : null;
        }

        public async Task<IEnumerable<AddCarBookingResponse>> GetAllCarBookingsAsync()
        {
            var bookings = await _carBookingRepo.GetAllAsync();
            return bookings?.Select(b => _mapper.Map<AddCarBookingResponse>(b));
        }

        public async Task<AddCarBookingResponse> AddCarBookingAsync(AddCarBookingRequest dto)
        {
            var car = await _carRepo.GetByIdAsync(dto.CarId)
                ?? throw new ArgumentException("Invalid Car ID");

            if (dto.NumberOfPassengers > car.Seats)
            {
                throw new Exception("Car capacity is less than the number of passengers wanted!");
            }
            var booking = new Booking
            {
                StartDateTime = dto.StartDateTime,
                EndDateTime = dto.EndDateTime,
                NumberOfPassengers = dto.NumberOfPassengers,
                Status = BType.Pending,
                BookingType = true // Assuming true = car booking
            };

            //var car = _mapper.Map<Car>(dto);
            
            /*var carBooking = _mapper.Map<CarBooking>(dto);
            carBooking.Booking = booking;
            carBooking.BookingId = booking.Id;
            // Ensure associated booking exists (if needed)
            if (carBooking.BookingId <= 0)
                throw new ArgumentException("Invalid booking reference");

            var addedBooking = await _carBookingRepo.AddAsync(carBooking);
            await _carBookingRepo.SaveChangesAsync();

            return _mapper.Map<AddCarBookingResponse>(addedBooking);*/
            
            var createdBooking = await _bookingRepo.AddAsync(booking);
            
            await _bookingRepo.SaveChangesAsync();



            
            // 2. Create CarBooking with valid BookingId
            var carBooking = _mapper.Map<CarBooking>(dto);
            carBooking.BookingId = createdBooking.Id;

            
            
            // 3. Save CarBooking
           // var addedCarBooking = await _carBookingRepo.AddAsync(carBooking);
            //await _carBookingRepo.SaveChangesAsync();
            var carBooking2 = _mapper.Map<AddCarBookingResponse>(carBooking);
            carBooking2.Pph = car.Pph;
            carBooking2.Seats = car.Seats;
            carBooking2.Color = car.Color;
            carBooking2.Model = car.Model;
            carBooking2.Mbw = car.Mbw;
            carBooking2.Ppd = car.Ppd;
           // var addedCar = _mapper.Map<AddCarBookingResponse>(carBooking2);
            var addedCar2 = _mapper.Map<CarBooking>(carBooking2);
            var addedCarBooking2 = await _carBookingRepo.AddAsync(addedCar2);
            await _carBookingRepo.SaveChangesAsync();
            //var addedCar = await _carBookingRepo.AddAsync(carBooking2);

            return _mapper.Map<AddCarBookingResponse>(addedCarBooking2);
            


            
        }

        public async Task<AddCarBookingResponse?> UpdateCarBookingAsync(int id, AddCarBookingRequest dto)
        {
            var existingBooking = await _carBookingRepo.GetByIdAsync(id);
            if (existingBooking == null) return null;

            _mapper.Map(dto, existingBooking);
            _carBookingRepo.Update(id, existingBooking);
            await _carBookingRepo.SaveChangesAsync();

            return _mapper.Map<AddCarBookingResponse>(existingBooking);
        }

        public async Task<AddCarBookingResponse> DeleteCarBookingAsync(int id)
        {
            var deletedBooking = await _carBookingRepo.RemoveAsync(id);
            await _carBookingRepo.SaveChangesAsync();
            return _mapper.Map<AddCarBookingResponse>(deletedBooking);
        }

        /*public Task<AddCarBookingResponse> CreateCarBookingAsync(AddCarBookingRequest dto)
        {
            throw new NotImplementedException();
        }*/
    }
}