using BLL.IServices;
using DataAccess.Entities;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CarsController : Controller
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }


    public async Task<IActionResult> GetCarById(int id)
    {
        var carDTO = await _carService.GetCarByIdAsync(id);

        if(carDTO == null) 
            return NotFound();

        return Ok(carDTO);
    }

    public async Task<IActionResult> GetAllCars()
    {
        return Ok(await _carService.GetAllCarsAsync());
    }


}
