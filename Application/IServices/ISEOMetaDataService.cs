using Domain.Entities.AppEntities;

namespace Application.IServices;

public interface ISEOMetaDataService
{
    public IEnumerable<SeoMetadata>? GetAllSEOMetaData();

    public SeoMetadata? GetSEOMetaDataById(int id);

    public SeoMetadata AddSEOMetaData(SeoMetadata seoMetadata);

    public SeoMetadata? UpdateSEOMetaData(int id, SeoMetadata seoMetadata);

    public SeoMetadata? DeleteSEOMetaData(int id);

    public Task<IEnumerable<SeoMetadata>?> GetAllSEOMetaDataAsync();

    public Task<SeoMetadata?> GetSEOMetaDataByIdAsync(int id);

    public Task<SeoMetadata> AddSEOMetaDataAsync(SeoMetadata seoMetadata);

    public Task<SeoMetadata?> UpdateSEOMetaDataAsync(int id, SeoMetadata seoMetadata);

    public Task<SeoMetadata?> DeleteSEOMetaDataAsync(int id);
}
