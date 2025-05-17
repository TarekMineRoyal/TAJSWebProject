using Application.DTOs.CarBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICarBookingService
    {
        Task<CarBookingDTO> CreateCarBookingAsync(CreateCarBookingDTO dto);
        Task<CarBookingDTO?> GetCarBookingByIdAsync(int id);
        Task<IEnumerable<CarBookingDTO>> GetAllCarBookingsAsync();
        Task<CarBookingDTO> UpdateCarBookingAsync(int id, UpdateCarBookingDTO dto);
        Task<CarBookingDTO> DeleteCarBookingAsync(int id);
    }
}
