// Application/Services/BookingService.cs
using Application.DTOs.Booking;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Payment;
using Domain.Entities.AppEntities;

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

        public async Task<BookingResponse?> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepo.GetByIdAsync(id);
            return booking != null ? _mapper.Map<BookingResponse>(booking) : null;
        }

        public async Task<IEnumerable<BookingResponse>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepo.GetAllAsync();
            var bookingsDto = new List<BookingResponse>();
            if (bookings != null)
            {
                foreach (Booking booking in bookings)
                {
                    bookingsDto.Add(_mapper.Map<BookingResponse>(booking));
                }
            }
            return bookingsDto;
        }

        public async Task<BookingResponse> AddBookingAsync(AddBookingRequest dto)
        {
            var booking = _mapper.Map<Booking>(dto);

            var addedBooking = await _bookingRepo.AddAsync(booking);
            await _bookingRepo.SaveChangesAsync();

            return _mapper.Map<BookingResponse>(addedBooking);
        }

        public async Task<BookingResponse?> UpdateBookingAsync(int id, AddBookingRequest dto)
        {
            var existingBooking = await _bookingRepo.GetByIdAsync(id);
            if (existingBooking == null) return null;

            _mapper.Map(dto, existingBooking);
            _bookingRepo.UpdateAsync(id, existingBooking);
            await _bookingRepo.SaveChangesAsync();

            return _mapper.Map<BookingResponse>(existingBooking);
        }

        public async Task<BookingResponse> DeleteBookingAsync(int id)
        {
            var deletedBooking = await _bookingRepo.RemoveAsync(id);
            await _bookingRepo.SaveChangesAsync();
            return _mapper.Map<BookingResponse>(deletedBooking);
        }
    }
}