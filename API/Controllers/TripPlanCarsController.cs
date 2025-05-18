// API/Controllers/TripPlanCarsController.cs
using Application.DTOs.TripPlanCar;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripPlanCarsController : ControllerBase
    {
        private readonly ITripPlanCarService _service;

        public TripPlanCarsController(ITripPlanCarService service)
        {
            _service = service;
        }

        // GET /api/tripplancars/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetTripPlanCarByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        // GET /api/tripplancars
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllTripPlanCarsAsync());
        }

        // POST /api/tripplancars
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTripPlanCarDTO dto)
        {
            var created = await _service.AddTripPlanCarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT /api/tripplancars/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTripPlanCarDTO dto)
        {
            var updated = await _service.UpdateTripPlanCarAsync(id, dto);
            return updated != null ? Ok(updated) : NotFound();
        }

        // DELETE /api/tripplancars/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTripPlanCarAsync(id);
            return NoContent();
        }
    }
}