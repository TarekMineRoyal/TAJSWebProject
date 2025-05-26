using Domain.Entities.AppEntities;

namespace Application.IServices;

public interface IPostService
{
    public IEnumerable<Post>? GetAllPosts();

    public Post? GetPostById(int id);

    public Post? AddPost(Post post, Guid employeeId);

    public Post? UpdatePost(int id, Post post, Guid employeeId);

    public Post? DeletePost(int id, Guid employeeId);

    public SeoMetadata? AddSEOMetaDataToPost(int postId, SeoMetadata seoMetadata);

    public SeoMetadata? UpdateSEOMetaDataToPost(int postId, SeoMetadata seoMetadata);

    public SeoMetadata? DeleteSEOMetaDataFromPost(int postId, int seoMetaDataId);

    public IEnumerable<Tag>? AddTagsToPost(int postId, IEnumerable<int> tagIds);

    public IEnumerable<Tag>? DeleteTagsFromPost(int postId, IEnumerable<int> tagIds);


    public Task<IEnumerable<Post>?> GetAllPostsAsync();

    public Task<Post?> GetPostByIdAsync(int id);

    public Task<Post?> AddPostAsync(Post post, Guid employeeId);

    public Task<Post?> UpdatePostAsync(int id, Post post, Guid employeeId);

    public Task<Post?> DeletePostAsync(int id, Guid employeeId);

    public Task<SeoMetadata?> AddSEOMetaDataToPostAsync(int postId, SeoMetadata seoMetadata);

    public Task<SeoMetadata?> UpdateSEOMetaDataToPostAsync(int postId, SeoMetadata seoMetadata);

    public Task<SeoMetadata?> DeleteSEOMetaDataFromPostAsync(int postId, int seoMetaDataId);

    public Task<IEnumerable<Tag>?> AddTagsToPostAsync(int postId, IEnumerable<int> tagIds);

    public Task<IEnumerable<Tag>?> DeleteTagsFromPostAsync(int postId, IEnumerable<int> tagIds);
}
