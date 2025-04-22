using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL.IServices;
using DTO;

namespace Presentation.Controllers
{
    //[Authorize(Roles = "Admin")]

    [Route("/Cars/[action]")] // Apply route at the controller level
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: /Cars/Index
        [Route("/Cars")]
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllCarsAsync();
            return View(cars);
        }

        // GET: /Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _carService.AddCarAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Cars/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var carDto = await _carService.GetCarByIdAsync(id);
            if (carDto == null)
                return NotFound();

            var updateDto = new UpdateCarDTO
            {
                Model = carDto.Model,
                Seats = carDto.Seats,
                Color = carDto.Color,
                Image = carDto.Image,
                Mbw = carDto.Mbw,
                Pph = carDto.Pph,
                Ppd = carDto.Ppd,
                CategoryId = carDto.CategoryId
            };

            return View(updateDto);
        }

        // POST: /Cars/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateCarDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var updatedCar = await _carService.UpdateCarAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Cars/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var carDto = await _carService.GetCarByIdAsync(id);
            if (carDto == null)
                return NotFound();

            return View(carDto);
        }

        // POST: /Cars/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _carService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}