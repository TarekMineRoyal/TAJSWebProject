// Application/IServices/IImageShotService.cs
using Application.DTOs.ImageShot;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IImageShotService
    {
        Task<ImageShotDTO?> GetImageShotByIdAsync(int id);
        Task<IEnumerable<ImageShotDTO>> GetAllImageShotsAsync();
        Task<CreateImageShotDTO> AddImageShotAsync(CreateImageShotDTO dto);
        Task<ImageShotDTO?> UpdateImageShotAsync(int id, UpdateImageShotDTO dto);
        Task<ImageShotDTO> DeleteImageShotAsync(int id);
    }
}