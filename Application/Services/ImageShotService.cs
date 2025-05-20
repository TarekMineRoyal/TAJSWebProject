// Application/Services/ImageShotService.cs
using Application.DTOs.ImageShot;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ImageShotService : IImageShotService
    {
        private readonly IGenericRepository<ImageShot> _imageShotRepo;
        private readonly IMapper _mapper;

        public ImageShotService(
            IGenericRepository<ImageShot> imageShotRepo,
            IMapper mapper)
        {
            _imageShotRepo = imageShotRepo;
            _mapper = mapper;
        }

        public async Task<ImageShotDTO?> GetImageShotByIdAsync(int id)
        {
            var image = await _imageShotRepo.GetByIdAsync(id);
            return image != null ? _mapper.Map<ImageShotDTO>(image) : null;
        }

        public async Task<IEnumerable<ImageShotDTO>> GetAllImageShotsAsync()
        {
            var images = await _imageShotRepo.GetAllAsync();
            return images?.Select(i => _mapper.Map<ImageShotDTO>(i));
        }

        public async Task<CreateImageShotDTO> AddImageShotAsync(CreateImageShotDTO dto)
        {
            var image = _mapper.Map<ImageShot>(dto);
            var addedImage = await _imageShotRepo.AddAsync(image);
            await _imageShotRepo.SaveChangesAsync();
            return _mapper.Map<CreateImageShotDTO>(addedImage);
        }

        public async Task<ImageShotDTO?> UpdateImageShotAsync(int id, UpdateImageShotDTO dto)
        {
            var existingImage = await _imageShotRepo.GetByIdAsync(id);
            if (existingImage == null) return null;

            _mapper.Map(dto, existingImage);
<<<<<<< HEAD
            _imageShotRepo.Update(existingImage);
=======
            _imageShotRepo.UpdateAsync(id, existingImage);
>>>>>>> Add-Post-Service
            await _imageShotRepo.SaveChangesAsync();

            return _mapper.Map<ImageShotDTO>(existingImage);
        }

        public async Task<ImageShotDTO> DeleteImageShotAsync(int id)
        {
            var deletedImage = await _imageShotRepo.RemoveAsync(id);
            await _imageShotRepo.SaveChangesAsync();
            return _mapper.Map<ImageShotDTO>(deletedImage);
        }
    }
}