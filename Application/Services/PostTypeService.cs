using Application.IRepositories;
using Application.IServices;
using Domain.Entities;

namespace Application.Services;

public class PostTypeService : IPostTypeService
{
    private readonly IGenericRepository<PostType> postTypeRepository;

    public PostTypeService(IGenericRepository<PostType> postTypeRepository)
    {
        this.postTypeRepository = postTypeRepository;
    }

    public PostType AddPostType(PostType postType)
    {
        postTypeRepository.Add(postType);
        postTypeRepository.SaveChanges();

        return postType;
    }

    public async Task<PostType> AddPostTypeAsync(PostType postType)
    {
        await postTypeRepository.AddAsync(postType);
        await postTypeRepository.SaveChangesAsync();

        return postType;
    }

    public PostType? DeletePostType(int id)
    {
        var postType = postTypeRepository.Remove(id);
        postTypeRepository.SaveChanges();

        return postType;
    }

    public async Task<PostType?> DeletePostTypeAsync(int id)
    {
        var postType = await postTypeRepository.RemoveAsync(id);
        await postTypeRepository.SaveChangesAsync();

        return postType;
    }

    public IEnumerable<PostType>? GetAllPostTypes()
    {
        return postTypeRepository.GetAll();
    }

    public async Task<IEnumerable<PostType>?> GetAllPostTypesAsync()
    {
        return await postTypeRepository.GetAllAsync();
    }

    public PostType? GetPostTypeById(int id)
    {
        return postTypeRepository.GetById(id);
    }

    public async Task<PostType?> GetPostTypeByIdAsync(int id)
    {
        return await postTypeRepository.GetByIdAsync(id);   
    }

    public PostType? UpdatePostType(int id, PostType postType)
    {
        postType.Id = id;
        var newPostType = postTypeRepository.Update(id, postType);
        postTypeRepository.SaveChanges();

        return newPostType;
    }

    public async Task<PostType?> UpdatePostTypeAsync(int id, PostType postType)
    {
        postType.Id = id;
        var newPostType = await postTypeRepository.UpdateAsync(id, postType);
        await postTypeRepository.SaveChangesAsync();

        return newPostType;
    }
}
