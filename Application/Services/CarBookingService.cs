using Application.DTOs.CarBooking;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CarBookingService : ICarBookingService
    {
        private readonly IGenericRepository<CarBooking> _carBookingRepo;
        private readonly IMapper _mapper;

        public CarBookingService(IGenericRepository<CarBooking> carBookingRepo, IMapper mapper)
        {
            _carBookingRepo = carBookingRepo;
            _mapper = mapper;
        }

        public async Task<CarBookingDTO?> GetCarBookingByIdAsync(int id)
        {
            var booking = await _carBookingRepo.GetByIdAsync(id);
            return booking != null ? _mapper.Map<CarBookingDTO>(booking) : null;
        }

        public async Task<IEnumerable<CarBookingDTO>> GetAllCarBookingsAsync()
        {
            var bookings = await _carBookingRepo.GetAllAsync();
            return bookings?.Select(b => _mapper.Map<CarBookingDTO>(b));
        }

        public async Task<CreateCarBookingDTO> AddCarBookingAsync(CreateCarBookingDTO dto)
        {
            var booking = _mapper.Map<CarBooking>(dto);

            // Ensure associated booking exists (if needed)
            if (booking.BookingId <= 0)
                throw new ArgumentException("Invalid booking reference");

            var addedBooking = await _carBookingRepo.AddAsync(booking);
            await _carBookingRepo.SaveChangesAsync();

            return _mapper.Map<CreateCarBookingDTO>(addedBooking);
        }

        public async Task<CarBookingDTO?> UpdateCarBookingAsync(int id, UpdateCarBookingDTO dto)
        {
            var existingBooking = await _carBookingRepo.GetByIdAsync(id);
            if (existingBooking == null) return null;

            _mapper.Map(dto, existingBooking);
            _carBookingRepo.Update(id, existingBooking);
            await _carBookingRepo.SaveChangesAsync();

            return _mapper.Map<CarBookingDTO>(existingBooking);
        }

        public async Task<CarBookingDTO> DeleteCarBookingAsync(int id)
        {
            var deletedBooking = await _carBookingRepo.RemoveAsync(id);
            await _carBookingRepo.SaveChangesAsync();
            return _mapper.Map<CarBookingDTO>(deletedBooking);
        }

        public Task<CarBookingDTO> CreateCarBookingAsync(CreateCarBookingDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}