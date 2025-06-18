// Application/IServices/ICarService.cs

using Application.DTOs.Car;

namespace Application.IServices;

public interface ICarService
{
    Task<CarDTO?> GetCarByIdAsync(int id);
    Task<PaginatedCarResponseDTO> GetAllCarsAsync(CarQueryParameters queryParameters);
    Task<CreateCarDTO> AddCarAsync(CreateCarDTO carAddDto);
    Task<CarDTO?> UpdateCarAsync(int id, UpdateCarDTO carUpdateDto);
    Task<CarDTO> DeleteCar(int id);
    Task<PaginatedCarResponseDTO> GetAvailableCarsAsync(DateTime startDateTime, DateTime endDateTime, CarQueryParameters queryParameters);
}