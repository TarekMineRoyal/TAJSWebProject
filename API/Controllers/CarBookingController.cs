using Application.DTOs.CarBooking;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarBookingsController : ControllerBase
    {
        private readonly ICarBookingService _carBookingService;

        public CarBookingsController(ICarBookingService carBookingService)
        {
            _carBookingService = carBookingService;
        }

        // GET /api/carbookings/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarBookingById(int id)
        {
            var booking = await _carBookingService.GetCarBookingByIdAsync(id);
            return booking != null ? Ok(booking) : NotFound();
        }

        // GET /api/carbookings
        [HttpGet]
        public async Task<IActionResult> GetAllCarBookings()
        {
            return Ok(await _carBookingService.GetAllCarBookingsAsync());
        }

        // POST /api/carbookings
        [HttpPost]
        public async Task<IActionResult> CreateCarBooking([FromBody] CreateCarBookingDTO dto)
        {
            var createdDto = await _carBookingService.AddCarBookingAsync(dto);
            return CreatedAtAction(nameof(GetCarBookingById), new { id = createdDto.Id }, createdDto);
        }

        // PUT /api/carbookings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarBooking(int id, [FromBody] UpdateCarBookingDTO dto)
        {
            var updated = await _carBookingService.UpdateCarBookingAsync(id, dto);
            return updated != null ? Ok(updated) : NotFound();
        }

        // DELETE /api/carbookings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarBooking(int id)
        {
            await _carBookingService.DeleteCarBookingAsync(id);
            return NoContent();
        }
    }
}