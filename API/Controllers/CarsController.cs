using DataAccess.Entities;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CarsController : Controller
{
    private readonly IGenericRepository<Car> _genericRepository;

    public CarsController(IGenericRepository<Car> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<IActionResult> GetCarById(int id)
    {
        var car = await _genericRepository.GetByIdAsync(id);

        if(car == null) 
            return NotFound();

        return Ok(car);
    }

    public async Task<IActionResult> GetAllCars()
    {
        return Ok(await _genericRepository.GetAllAsync());
    }


}
