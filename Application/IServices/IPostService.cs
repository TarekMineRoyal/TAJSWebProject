using Domain.Entities;

namespace Application.IServices;

public interface IPostService
{
    public IEnumerable<Post>? GetAllPosts();

    public Post? GetPostById(int id);

    public Post AddPost(Post post);

    public Post UpdatePost(Post post);

    public Post? DeletePost(int id);

    public Task<IEnumerable<Post>?> GetAllPostsAsync();

    public Task<Post?> GetPostByIdAsync(int id);

    public Task<Post> AddPostAsync(Post post);

    public Task<Post> UpdatePostAsync(Post post);

    public Task<Post?> DeletePostAsync(int id);
}
