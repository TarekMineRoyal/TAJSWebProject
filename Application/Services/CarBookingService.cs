// Application/Services/CarBookingService.cs
using Application.DTOs.CarBooking;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.AppEntities;
using Application.DTOs.Car;
using Application.DTOs.Payment;

namespace Application.Services
{
    public class CarBookingService : ICarBookingService
    {
        private readonly IGenericRepository<CarBooking> _carBookingRepo;
        private readonly IGenericRepository<Car> _carRepo;
        private readonly IGenericRepository<Booking> _bookingRepo;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;

        public CarBookingService(IGenericRepository<CarBooking> carBookingRepo,
            IGenericRepository<Car> carRepo,
            IGenericRepository<Booking> bookingRepo, IMapper mapper,
            IPaymentService paymentService)
        {
            _carBookingRepo = carBookingRepo;
            _bookingRepo = bookingRepo;
            _carRepo = carRepo;
            _mapper = mapper;
            _paymentService = paymentService;
        }

        public async Task<AddCarBookingResponse?> GetCarBookingByIdAsync(int id)
        {
            var booking = await _carBookingRepo.GetByIdAsync(id);
            return booking != null ? _mapper.Map<AddCarBookingResponse>(booking) : null;
        }

        public async Task<IEnumerable<AddCarBookingResponse>> GetAllCarBookingsAsync()
        {
            var carBookings = await _carBookingRepo.GetAllAsync();
            var carBookingsDto = new List<AddCarBookingResponse>();

            if (carBookings is not null)
            {
                foreach (CarBooking carBooking in carBookings)
                {
                    var car = _carRepo.GetById(carBooking.CarId);
                    var x = carBooking;
                    x.Car = car;
                    carBookingsDto.Add(_mapper.Map<AddCarBookingResponse>(carBooking));
                }
            }

            return carBookingsDto;
        }

        public async Task<AddCarBookingResponse> AddCarBookingAsync(AddCarBookingRequest dto)
        {
            var car = await _carRepo.GetByIdAsync(dto.CarId)
                ?? throw new ArgumentException("Invalid Car ID");

            if (dto.NumberOfPassengers > car.Seats || (dto.WithDriver && dto.NumberOfPassengers + 1 > car.Seats))
            {
                throw new Exception("Car capacity is less than the number of passengers wanted!");
            }
            var booking = new Booking
            {
                StartDateTime = dto.StartDateTime,
                EndDateTime = dto.EndDateTime,
                NumberOfPassengers = dto.NumberOfPassengers,
                Status = BType.Pending,
                BookingType = true
            };

            var createdBooking = await _bookingRepo.AddAsync(booking);

            await _bookingRepo.SaveChangesAsync();


            CarBooking carBooking = new CarBooking();
            carBooking.CarId = car.Id;
            carBooking = _mapper.Map<CarBooking>(dto);
            carBooking.BookingId = createdBooking.Id;



            var addedCarBooking = await _carBookingRepo.AddAsync(carBooking);
            await _carBookingRepo.SaveChangesAsync();

            var duration = booking.EndDateTime - booking.StartDateTime;

            var paymentDto = new RequestPaymentDTO
            {
                BookingId = createdBooking.Id,
                Status = StatusEnum.Pending,
                AmountDue = duration.Days * car.Ppd + duration.Hours * car.Pph,
                AmountPaid = 0,
                PaymentDate = DateTime.UtcNow
            };
            await _paymentService.AddPayment(paymentDto);

            return _mapper.Map<AddCarBookingResponse>(addedCarBooking);

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
    }
}