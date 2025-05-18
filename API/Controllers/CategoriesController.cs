using Application.DTOs.Category;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET /api/categories/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return category != null ? Ok(category) : NotFound();
        }

        // GET /api/categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }

        // POST /api/categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO dto)
        {
            var createdDto = await _categoryService.AddCategoryAsync(dto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdDto.Id }, createdDto);
        }

        // PUT /api/categories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO dto)
        {
            var updated = await _categoryService.UpdateCategoryAsync(id, dto);
            return updated != null ? Ok(updated) : NotFound();
        }

        // DELETE /api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}