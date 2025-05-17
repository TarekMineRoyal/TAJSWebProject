using Application.DTOs.Category;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<CategoryDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            return category != null ? _mapper.Map<CategoryDTO>(category) : null;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return categories?.Select(c => _mapper.Map<CategoryDTO>(c));
        }

        public async Task<CreateCategoryDTO> AddCategoryAsync(CreateCategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            var addedCategory = await _categoryRepo.AddAsync(category);
            await _categoryRepo.SaveChangesAsync();
            return _mapper.Map<CreateCategoryDTO>(addedCategory);
        }

        public async Task<CategoryDTO?> UpdateCategoryAsync(int id, UpdateCategoryDTO dto)
        {
            var existingCategory = await _categoryRepo.GetByIdAsync(id);
            if (existingCategory == null) return null;

            _mapper.Map(dto, existingCategory);
            _categoryRepo.Update(existingCategory);
            await _categoryRepo.SaveChangesAsync();

            return _mapper.Map<CategoryDTO>(existingCategory);
        }

        public async Task<CategoryDTO> DeleteCategoryAsync(int id)
        {
            var deletedCategory = await _categoryRepo.RemoveAsync(id);
            await _categoryRepo.SaveChangesAsync();
            return _mapper.Map<CategoryDTO>(deletedCategory);
        }
    }
}