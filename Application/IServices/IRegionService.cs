// Application/IServices/IRegionService.cs
using Application.DTOs.Region;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IRegionService
    {
        Task<ResponseRegionDTO?> GetRegionByIdAsync(int id);
        Task<IEnumerable<ResponseRegionDTO>> GetAllRegionsAsync();
        Task<ResponseRegionDTO> AddRegionAsync(RequestRegionDTO dto);
        Task<ResponseRegionDTO?> UpdateRegionAsync(int id, RequestRegionDTO dto);
        Task<ResponseRegionDTO> DeleteRegionAsync(int id);
    }
}