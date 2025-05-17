using Application.DTOs.CarBooking;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICarBookingService
    {
        Task<CarBookingDTO?> GetCarBookingByIdAsync(int id);
        Task<IEnumerable<CarBookingDTO>> GetAllCarBookingsAsync();
        Task<CreateCarBookingDTO> AddCarBookingAsync(CreateCarBookingDTO dto);
        Task<CarBookingDTO?> UpdateCarBookingAsync(int id, UpdateCarBookingDTO dto);
        Task<CarBookingDTO> DeleteCarBookingAsync(int id);
    }
}