// API/Controllers/CarController.cs

using Application.DTOs.Car;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    // GET: api/cars/available
    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableCars([FromQuery] DateTime startDateTime, [FromQuery] DateTime endDateTime, [FromQuery] CarQueryParameters queryParameters)
    {
        if (startDateTime >= endDateTime)
        {
            return BadRequest("Start date must be earlier than end date.");
        }
        var availableCars = await _carService.GetAvailableCarsAsync(startDateTime, endDateTime, queryParameters);
        return Ok(availableCars);
    }


    // GET /api/cars/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarById(int id)
    {
        var car = await _carService.GetCarByIdAsync(id);
        return car != null ? Ok(car) : NotFound();
    }

    // GET /api/cars
    [HttpGet]
    public async Task<IActionResult> GetAllCars([FromQuery] CarQueryParameters queryParameters)
    {
        var cars = await _carService.GetAllCarsAsync(queryParameters);
        return Ok(cars);
    }

    // POST /api/cars
    [HttpPost]
    public async Task<IActionResult> CreateCar([FromBody] CreateCarDTO dto)
    {
        var createdDto = await _carService.AddCarAsync(dto);
        return CreatedAtAction(nameof(GetCarById), new { id = createdDto.Id }, createdDto);
    }

    // PUT /api/cars/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCar(int id, [FromBody] UpdateCarDTO dto)
    {
        var updatedCar = await _carService.UpdateCarAsync(id, dto);
        return updatedCar != null ? Ok(updatedCar) : NotFound();
    }

    // DELETE /api/cars/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        await _carService.DeleteCar(id);
        return NoContent();
    }
}