using Application.DTOs.CarBooking;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarBookingController : Controller
{
    private CarBookingService _carBookingService;

    public CarBookingController(CarBookingService carBookingService) 
    {
        _carBookingService = carBookingService;
    }

    //public IActionResult Index()
    //{
    //    return View();
    //}

    [HttpPost]
    public async Task<IActionResult> CreateCarBooking(CreateCarBookingDTO createCarBookingDTO)
    {
        createCarBookingDTO = await _carBookingService.AddCarBookingAsync(createCarBookingDTO);
        if(createCarBookingDTO is null)
        {
            return BadRequest("Something goes wrong!");
        }
        else
        {
            return Ok(createCarBookingDTO);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetCarBookingAsync(int id)
    {
        var carBooking = await _carBookingService.GetCarBookingAsync(id);
        if (carBooking is null)
        {
            return BadRequest("Car booking not found.");
        }
        return Ok(carBooking);
    }
}
