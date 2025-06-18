using Application.DTOs.TripBooking;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripBookingsController : ControllerBase
    {
        private readonly ITripBookingService _tripBookingService;

        public TripBookingsController(ITripBookingService tripBookingService)
        {
            _tripBookingService = tripBookingService;
        }

        // GET /api/tripbookings/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripBookingById(int id)
        {
            var booking = await _tripBookingService.GetTripBookingByIdAsync(id);
            return booking != null ? Ok(booking) : NotFound();
        }

        // GET /api/tripbookings
        [HttpGet]
        public async Task<IActionResult> GetAllTripBookings()
        {
            return Ok(await _tripBookingService.GetAllTripBookingsAsync());
        }

        // POST /api/tripbookings
        [HttpPost]
        public async Task<IActionResult> CreateTripBooking([FromBody] CreateTripBookingRequestDTO dto) // CHANGED HERE
        {
            // Note: The service will now return a more complete object, but the frontend
            // just needs a successful response to proceed.
            var createdBooking = await _tripBookingService.AddTripBookingAsync(dto);
            return CreatedAtAction(nameof(GetTripBookingById), new { id = createdBooking.Id }, createdBooking);
        }

        // PUT /api/tripbookings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTripBooking(int id, [FromBody] UpdateTripBookingDTO dto)
        {
            var updated = await _tripBookingService.UpdateTripBookingAsync(id, dto);
            return updated != null ? Ok(updated) : NotFound();
        }

        // DELETE /api/tripbookings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripBooking(int id)
        {
            await _tripBookingService.DeleteTripBookingAsync(id);
            return NoContent();
        }
    }
}