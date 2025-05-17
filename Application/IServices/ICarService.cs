using Application.DTOs.Car;

namespace Application.IServices;

public interface ICarService
{
    Task<CarDTO?> GetCarByIdAsync(int id);
    Task<IEnumerable<CarDTO>?> GetAllCarsAsync();
    Task<CreateCarDTO> AddCarAsync(CreateCarDTO carAddDto);
    Task<CarDTO?> UpdateCarAsync(int id, UpdateCarDTO carUpdateDto);
    Task<CarDTO> DeleteCar(int id);

}
