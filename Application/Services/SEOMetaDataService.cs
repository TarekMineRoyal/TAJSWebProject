using Application.IRepositories;
using Application.IServices;
using Domain.Entities.AppEntities;

namespace Application.Services;

public class SEOMetaDataService : ISEOMetaDataService
{
    private readonly IGenericRepository<SeoMetadata> seoMetaDataRepository;

    public SEOMetaDataService(IGenericRepository<SeoMetadata> seoMetaDataRepository)
    {
        this.seoMetaDataRepository = seoMetaDataRepository;
    }

    public SeoMetadata AddSEOMetaData(SeoMetadata seoMetadata)
    {
        var returnedSEOMetaData = seoMetaDataRepository.Add(seoMetadata);
        seoMetaDataRepository.SaveChanges();

        return returnedSEOMetaData;
    }

    public async Task<SeoMetadata> AddSEOMetaDataAsync(SeoMetadata seoMetadata)
    {
        var returnedSEOMetaData = await seoMetaDataRepository.AddAsync(seoMetadata);
        await seoMetaDataRepository.SaveChangesAsync();

        return seoMetadata;
    }

    public SeoMetadata? DeleteSEOMetaData(int id)
    {
        var returnedSEOMetaData = seoMetaDataRepository.Remove(id);
        seoMetaDataRepository.SaveChanges();

        return returnedSEOMetaData;
    }

    public async Task<SeoMetadata?> DeleteSEOMetaDataAsync(int id)
    {
        var returnedSEOMetaData = seoMetaDataRepository.Remove(id);
        await seoMetaDataRepository.SaveChangesAsync();

        return returnedSEOMetaData;
    }

    public IEnumerable<SeoMetadata>? GetAllSEOMetaData()
    {
        return seoMetaDataRepository.GetAll();
    }

    public async Task<IEnumerable<SeoMetadata>?> GetAllSEOMetaDataAsync()
    {
        return await seoMetaDataRepository.GetAllAsync();
    }

    public SeoMetadata? GetSEOMetaDataById(int id)
    {
        return seoMetaDataRepository.GetById(id);
    }

    public async Task<SeoMetadata?> GetSEOMetaDataByIdAsync(int id)
    {
        return await seoMetaDataRepository.GetByIdAsync(id);
    }

    public SeoMetadata? UpdateSEOMetaData(int id, SeoMetadata seoMetadata)
    {
        seoMetadata.Id = id;

        var returnedSEOMetaData = seoMetaDataRepository.Update(id, seoMetadata);
        seoMetaDataRepository.SaveChanges();

        return returnedSEOMetaData;
    }

    public async Task<SeoMetadata?> UpdateSEOMetaDataAsync(int id, SeoMetadata seoMetadata)
    {
        seoMetadata.Id = id;

        var returnedSEOMetaData = seoMetaDataRepository.Update(id, seoMetadata);
         await seoMetaDataRepository.SaveChangesAsync();

        return returnedSEOMetaData;
    }
}
