// API/Controllers/ImageShotsController.cs
using Application.DTOs.ImageShot;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageShotsController : ControllerBase
    {
        private readonly IImageShotService _imageShotService;

        public ImageShotsController(IImageShotService imageShotService)
        {
            _imageShotService = imageShotService;
        }

        // GET /api/imageshots/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageShotById(int id)
        {
            var image = await _imageShotService.GetImageShotByIdAsync(id);
            return image != null ? Ok(image) : NotFound();
        }

        // GET /api/imageshots
        [HttpGet]
        public async Task<IActionResult> GetAllImageShots()
        {
            return Ok(await _imageShotService.GetAllImageShotsAsync());
        }

        // POST /api/imageshots
        [HttpPost]
        public async Task<IActionResult> CreateImageShot([FromBody] CreateImageShotDTO dto)
        {
            var createdDto = await _imageShotService.AddImageShotAsync(dto);
            return CreatedAtAction(nameof(GetImageShotById), new { id = createdDto.Id }, createdDto);
        }

        // PUT /api/imageshots/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImageShot(int id, [FromBody] UpdateImageShotDTO dto)
        {
            var updated = await _imageShotService.UpdateImageShotAsync(id, dto);
            return updated != null ? Ok(updated) : NotFound();
        }

        // DELETE /api/imageshots/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageShot(int id)
        {
            await _imageShotService.DeleteImageShotAsync(id);
            return NoContent();
        }
    }
}