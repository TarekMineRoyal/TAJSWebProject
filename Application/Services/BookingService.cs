// Application/Services/BookingService.cs
using Application.DTOs.Booking;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IGenericRepository<Booking> _bookingRepo;
        private readonly IMapper _mapper;

        public BookingService(
            IGenericRepository<Booking> bookingRepo,
            IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
        }

        public async Task<BookingDTO?> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepo.GetByIdAsync(id);
            return booking != null ? _mapper.Map<BookingDTO>(booking) : null;
        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepo.GetAllAsync();
            return bookings?.Select(b => _mapper.Map<BookingDTO>(b));
        }

        public async Task<CreateBookingDTO> AddBookingAsync(CreateBookingDTO dto)
        {
            var booking = _mapper.Map<Booking>(dto);

            var addedBooking = await _bookingRepo.AddAsync(booking);
            await _bookingRepo.SaveChangesAsync();

            return _mapper.Map<CreateBookingDTO>(addedBooking);
        }

        public async Task<BookingDTO?> UpdateBookingAsync(int id, UpdateBookingDTO dto)
        {
            var existingBooking = await _bookingRepo.GetByIdAsync(id);
            if (existingBooking == null) return null;

            _mapper.Map(dto, existingBooking);
            _bookingRepo.UpdateAsync(id, existingBooking);
            await _bookingRepo.SaveChangesAsync();

            return _mapper.Map<BookingDTO>(existingBooking);
        }

        public async Task<BookingDTO> DeleteBookingAsync(int id)
        {
            var deletedBooking = await _bookingRepo.RemoveAsync(id);
            await _bookingRepo.SaveChangesAsync();
            return _mapper.Map<BookingDTO>(deletedBooking);
        }
    }
}