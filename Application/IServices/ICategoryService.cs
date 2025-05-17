using Application.DTOs.Category;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICategoryService
    {
        Task<CategoryDTO?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task<CreateCategoryDTO> AddCategoryAsync(CreateCategoryDTO dto);
        Task<CategoryDTO?> UpdateCategoryAsync(int id, UpdateCategoryDTO dto);
        Task<CategoryDTO> DeleteCategoryAsync(int id);
    }
}