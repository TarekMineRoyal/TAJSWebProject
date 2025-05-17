// API/Controllers/RegionsController.cs
using Application.DTOs.Region;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        // GET /api/regions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegionById(int id)
        {
            var region = await _regionService.GetRegionByIdAsync(id);
            return region != null ? Ok(region) : NotFound();
        }

        // GET /api/regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            return Ok(await _regionService.GetAllRegionsAsync());
        }

        // POST /api/regions
        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] CreateRegionDTO dto)
        {
            var createdDto = await _regionService.AddRegionAsync(dto);
            return CreatedAtAction(nameof(GetRegionById), new { id = createdDto.Id }, createdDto);
        }

        // PUT /api/regions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion(int id, [FromBody] UpdateRegionDTO dto)
        {
            var updated = await _regionService.UpdateRegionAsync(id, dto);
            return updated != null ? Ok(updated) : NotFound();
        }

        // DELETE /api/regions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            await _regionService.DeleteRegionAsync(id);
            return NoContent();
        }
    }
}