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
        private IGenericRepository<Booking> _bookingRepository;
        private readonly IPaymentService _paymentService;
        IGenericRepository<CarBooking> _carBookingRepository;
        public CarBookingService(IGenericRepository<Car> carRepository, IGenericRepository<CarBooking> carBookingRepository, 
            CarService carService, IMapper mapper,IPaymentService paymentService, IGenericRepository<Booking> bookingRepository)
        {
            _paymentService = paymentService;
            _carBookingRepository = carBookingRepository;
            _carRepository = carRepository;
            _carService  = carService;
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }

        public async Task<CreateCarBookingDTO> AddCarBookingAsync(CreateCarBookingDTO createCarBookingDTO)
        {
            var booking = new Booking()
            {
                StartDateTime = createCarBookingDTO.StartDateTime,
                EndDateTime = createCarBookingDTO.EndDateTime,

            }; 
            var carBooking = _mapper.Map<CarBooking>(createCarBookingDTO);
            booking.Status = BType.Pending;
            booking.BookingType = true;
            booking = await _bookingRepository.AddAsync(booking);
            carBooking.BookingId = booking.Id;
            carBooking.CarId = createCarBookingDTO.CarId;
            carBooking = await _carBookingRepository.AddAsync(carBooking);
            if (booking is null || carBooking is null)
            {
                throw new Exception("Something is wrong!");
            }
            _bookingRepository.SaveChanges();
            _carBookingRepository.SaveChanges();
            return createCarBookingDTO;
        }

        public async Task<CarBookingDTO> GetCarBookingAsync(int id)
        {
            var carBooking = await _carBookingRepository.GetByIdAsync(id);
            if (carBooking is null)
            {
                return null;
            }
            return _mapper.Map<CarBookingDTO>(carBooking);
        }
    }
}
