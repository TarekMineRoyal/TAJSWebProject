using Domain.Entities;

namespace Application.IServices;

public interface IPostService
{
    public IEnumerable<Post> GetAllPosts();

    public IEnumerable<Post> GetPostById(int id);

    public Post AddPost(Post post);

    public Post UpdatePost(Post post);

    public Post DeletePost(Post post);

    public IEnumerable<Post> GetAllPostsAsync();

    public IEnumerable<Post> GetPostByIdAsync(int id);

    public Post AddPostAsync(Post post);

    public Post UpdatePostAsync(Post post);

    public Post DeletePostAsync(Post post);
}
