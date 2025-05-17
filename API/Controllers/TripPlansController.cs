// API/Controllers/TripPlansController.cs
using Application.DTOs.TripPlan;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripPlansController : ControllerBase
    {
        private readonly ITripPlanService _tripPlanService;

        public TripPlansController(ITripPlanService tripPlanService)
        {
            _tripPlanService = tripPlanService;
        }

        // GET /api/tripplans/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripPlanById(int id)
        {
            var plan = await _tripPlanService.GetTripPlanByIdAsync(id);
            return plan != null ? Ok(plan) : NotFound();
        }

        // GET /api/tripplans
        [HttpGet]
        public async Task<IActionResult> GetAllTripPlans()
        {
            return Ok(await _tripPlanService.GetAllTripPlansAsync());
        }

        // POST /api/tripplans
        [HttpPost]
        public async Task<IActionResult> CreateTripPlan([FromBody] CreateTripPlanDTO dto)
        {
            var createdDto = await _tripPlanService.AddTripPlanAsync(dto);
            return CreatedAtAction(nameof(GetTripPlanById), new { id = createdDto.Id }, createdDto);
        }

        // PUT /api/tripplans/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTripPlan(int id, [FromBody] UpdateTripPlanDTO dto)
        {
            var updated = await _tripPlanService.UpdateTripPlanAsync(id, dto);
            return updated != null ? Ok(updated) : NotFound();
        }

        // DELETE /api/tripplans/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripPlan(int id)
        {
            await _tripPlanService.DeleteTripPlanAsync(id);
            return NoContent();
        }
    }
}