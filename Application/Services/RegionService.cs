// Application/Services/RegionService.cs
using Application.DTOs.Region;
using Application.IServices;
using Application.IRepositories;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class RegionService : IRegionService
    {
        private readonly IGenericRepository<Region> _regionRepo;
        private readonly IMapper _mapper;

        public RegionService(
            IGenericRepository<Region> regionRepo,
            IMapper mapper)
        {
            _regionRepo = regionRepo;
            _mapper = mapper;
        }

        public async Task<RegionDTO?> GetRegionByIdAsync(int id)
        {
            var region = await _regionRepo.GetByIdAsync(id);
            return region != null ? _mapper.Map<RegionDTO>(region) : null;
        }

        public async Task<IEnumerable<RegionDTO>> GetAllRegionsAsync()
        {
            var regions = await _regionRepo.GetAllAsync();
            return regions?.Select(r => _mapper.Map<RegionDTO>(r));
        }

        public async Task<CreateRegionDTO> AddRegionAsync(CreateRegionDTO dto)
        {
            var region = _mapper.Map<Region>(dto);
            var addedRegion = await _regionRepo.AddAsync(region);
            await _regionRepo.SaveChangesAsync();
            return _mapper.Map<CreateRegionDTO>(addedRegion);
        }

        public async Task<RegionDTO?> UpdateRegionAsync(int id, UpdateRegionDTO dto)
        {
            var existingRegion = await _regionRepo.GetByIdAsync(id);
            if (existingRegion == null) return null;

            _mapper.Map(dto, existingRegion);
            _regionRepo.Update(existingRegion);
            await _regionRepo.SaveChangesAsync();

            return _mapper.Map<RegionDTO>(existingRegion);
        }

        public async Task<RegionDTO> DeleteRegionAsync(int id)
        {
            var deletedRegion = await _regionRepo.RemoveAsync(id);
            await _regionRepo.SaveChangesAsync();
            return _mapper.Map<RegionDTO>(deletedRegion);
        }
    }
}