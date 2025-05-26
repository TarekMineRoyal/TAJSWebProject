using Domain.Entities.AppEntities;

namespace Application.IServices;

public interface IPostTypeService
{
    public IEnumerable<PostType>? GetAllPostTypes();

    public PostType? GetPostTypeById(int id);

    public PostType AddPostType(PostType postType);

    public PostType? UpdatePostType(int id, PostType postType);

    public PostType? DeletePostType(int id);

    public Task<IEnumerable<PostType>?> GetAllPostTypesAsync();

    public Task<PostType?> GetPostTypeByIdAsync(int id);

    public Task<PostType> AddPostTypeAsync(PostType postType);

    public Task<PostType?> UpdatePostTypeAsync(int id, PostType postType);

    public Task<PostType?> DeletePostTypeAsync(int id);
}
