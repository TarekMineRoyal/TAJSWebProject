using Application.DTOs.CarBooking;
using Application.DTOs.Payment;
using Application.DTOs.TripBooking;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Domain.Entities.AppEntities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class TripBookingService : ITripBookingService
    {
        private readonly IGenericRepository<TripBooking> _tripBookingRepo;
        private readonly IGenericRepository<TripPlanCar> _tripPlanCarRepo;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;
        // This repository was missing
        private readonly IGenericRepository<Booking> _bookingRepo;

        public TripBookingService(
            IGenericRepository<TripBooking> tripBookingRepo,
            IGenericRepository<TripPlanCar> tripPlanCarRepo,
            IMapper mapper,
            IPaymentService paymentService,
            // Add the missing repository to the constructor
            IGenericRepository<Booking> bookingRepo)
        {
            _tripBookingRepo = tripBookingRepo;
            _tripPlanCarRepo = tripPlanCarRepo;
            _mapper = mapper;
            _paymentService = paymentService;
            // Initialize it
            _bookingRepo = bookingRepo;
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

        // The method signature and logic are now corrected
        public async Task<TripBookingDTO> AddTripBookingAsync(CreateTripBookingRequestDTO dto)
        {
            // 1. Create the generic Booking object first
            var booking = new Booking
            {
                BookingType = false, // false for Trip
                StartDateTime = dto.BookingType == "private" ? dto.StartDate.Value : DateTime.UtcNow,
                EndDateTime = dto.BookingType == "private" ? dto.EndDate.Value : DateTime.UtcNow,
                NumberOfPassengers = dto.Seats,
                Status = BType.Approved, // Assume booking is approved after payment
            };

            var createdBooking = await _bookingRepo.AddAsync(booking);
            await _bookingRepo.SaveChangesAsync();

            // 2. Create the specific TripBooking
            var tripBooking = new TripBooking
            {
                BookingId = createdBooking.Id,
                TripPlanId = dto.TripId,
            };

            var addedTripBooking = await _tripBookingRepo.AddAsync(tripBooking);
            await _tripBookingRepo.SaveChangesAsync();

            // 3. Create the final Payment record with the correct status from PayPal
            var paymentDto = new RequestPaymentDTO
            {
                BookingId = createdBooking.Id,
                // CORRECTED: Uses the actual enum members from your Payment.cs file
                Status = dto.PaymentStatus == "COMPLETED" ? StatusEnum.Complete : StatusEnum.Pending,
                AmountDue = dto.TotalPrice,
                AmountPaid = dto.TotalPrice,
                PaymentDate = DateTime.UtcNow
            };
            await _paymentService.AddPayment(paymentDto);

            return _mapper.Map<TripBookingDTO>(addedTripBooking);
        }

        public async Task<TripBookingDTO?> UpdateTripBookingAsync(int id, UpdateTripBookingDTO dto)
        {
            var existingBooking = await _tripBookingRepo.GetByIdAsync(id);
            if (existingBooking == null) return null;

            _mapper.Map(dto, existingBooking);
            _tripBookingRepo.Update(id, existingBooking);
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