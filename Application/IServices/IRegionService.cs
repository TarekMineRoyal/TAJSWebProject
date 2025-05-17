// Application/IServices/IRegionService.cs
using Application.DTOs.Region;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IRegionService
    {
        Task<RegionDTO?> GetRegionByIdAsync(int id);
        Task<IEnumerable<RegionDTO>> GetAllRegionsAsync();
        Task<CreateRegionDTO> AddRegionAsync(CreateRegionDTO dto);
        Task<RegionDTO?> UpdateRegionAsync(int id, UpdateRegionDTO dto);
        Task<RegionDTO> DeleteRegionAsync(int id);
    }
}