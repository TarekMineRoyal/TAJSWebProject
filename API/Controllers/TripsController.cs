// API/Controllers/TripsController.cs
using Application.DTOs.Trip;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }

        // GET /api/trips/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripById(int id)
        {
            var trip = await _tripService.GetTripByIdAsync(id);
            return trip != null ? Ok(trip) : NotFound();
        }

        // GET /api/trips
        [HttpGet]
        public async Task<IActionResult> GetAllTrips()
        {
            return Ok(await _tripService.GetAllTripsAsync());
        }

        // POST /api/trips
        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] CreateTripDTO dto)
        {
            var createdDto = await _tripService.AddTripAsync(dto);
            return CreatedAtAction(nameof(GetTripById), new { id = createdDto.Id }, createdDto);
        }

        // PUT /api/trips/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(int id, [FromBody] UpdateTripDTO dto)
        {
            var updated = await _tripService.UpdateTripAsync(id, dto);
            return updated != null ? Ok(updated) : NotFound();
        }

        // DELETE /api/trips/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            await _tripService.DeleteTripAsync(id);
            return NoContent();
        }
    }
}