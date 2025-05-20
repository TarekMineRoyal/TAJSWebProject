// API/Controllers/BookingsController.cs
using Application.DTOs.Booking;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET /api/bookings/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            return booking != null ? Ok(booking) : NotFound();
        }

        // GET /api/bookings
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            return Ok(await _bookingService.GetAllBookingsAsync());
        }

        // POST /api/bookings
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDTO dto)
        {
            var createdDto = await _bookingService.AddBookingAsync(dto);
            return CreatedAtAction(nameof(GetBookingById), new { id = createdDto.Id }, createdDto);
        }

        // PUT /api/bookings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] CreateBookingDTO dto)
        {
            var updated = await _bookingService.UpdateBookingAsync(id, dto);
            return updated != null ? Ok(updated) : NotFound();
        }

        // DELETE /api/bookings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return NoContent();
        }
    }
}