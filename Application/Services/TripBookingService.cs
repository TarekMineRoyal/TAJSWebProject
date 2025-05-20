using Application.DTOs.TripBooking;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class TripBookingService : ITripBookingService
    {
        private readonly IGenericRepository<TripBooking> _tripBookingRepo;
        private readonly IMapper _mapper;

        public TripBookingService(
            IGenericRepository<TripBooking> tripBookingRepo,
            IMapper mapper)
        {
            _tripBookingRepo = tripBookingRepo;
            _mapper = mapper;
        }

        public async Task<TripBookingDTO?> GetTripBookingByIdAsync(int id)
        {
            var booking = await _tripBookingRepo.GetByIdAsync(id);
            return booking != null ? _mapper.Map<TripBookingDTO>(booking) : null;
        }

        public async Task<IEnumerable<TripBookingDTO>> GetAllTripBookingsAsync()
        {
            var bookings = await _tripBookingRepo.GetAllAsync();
            return bookings?.Select(b => _mapper.Map<TripBookingDTO>(b));
        }

        public async Task<CreateTripBookingDTO> AddTripBookingAsync(CreateTripBookingDTO dto)
        {
            var booking = _mapper.Map<TripBooking>(dto);

            // Validate associated booking exists
            if (booking.BookingId <= 0)
                throw new ArgumentException("Invalid booking reference");

            var addedBooking = await _tripBookingRepo.AddAsync(booking);
            await _tripBookingRepo.SaveChangesAsync();

            return _mapper.Map<CreateTripBookingDTO>(addedBooking);
        }

        public async Task<TripBookingDTO?> UpdateTripBookingAsync(int id, UpdateTripBookingDTO dto)
        {
            var existingBooking = await _tripBookingRepo.GetByIdAsync(id);
            if (existingBooking == null) return null;

            _mapper.Map(dto, existingBooking);
            _tripBookingRepo.UpdateAsync(id, existingBooking);
            await _tripBookingRepo.SaveChangesAsync();

            return _mapper.Map<TripBookingDTO>(existingBooking);
        }

        public async Task<TripBookingDTO> DeleteTripBookingAsync(int id)
        {
            var deletedBooking = await _tripBookingRepo.RemoveAsync(id);
            await _tripBookingRepo.SaveChangesAsync();
            return _mapper.Map<TripBookingDTO>(deletedBooking);
        }
    }
}