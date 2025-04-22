using BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsController : Controller
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet("id:int")]
    public async Task<IActionResult> GetCarById(int id)
    {
        var carDTO = await _carService.GetCarByIdAsync(id);

        if (carDTO == null)
            return NotFound();

        return Ok(carDTO);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        return Ok(await _carService.GetAllCarsAsync());
    }


}