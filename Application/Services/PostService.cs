using Application.IRepositories;
using Application.IServices;
using Domain.Entities;

namespace Application.Services;

public class PostService : IPostService
{
    private readonly IGenericRepository<Post> postRepository;

    public PostService(IGenericRepository<Post> postRepository)
    {
        this.postRepository = postRepository;
    }

    public Post AddPost(Post post)
    {
        var returnedPpost = postRepository.Add(post);

        postRepository.SaveChanges();

        return returnedPpost;
    }

    public async Task<Post> AddPostAsync(Post post)
    {
        var returnedPpost = await postRepository.AddAsync(post);

        postRepository.SaveChanges();

        return returnedPpost;
    }

    public Post? DeletePost(int id)
    {
        var returnedPost = postRepository.Remove(id);

        postRepository.SaveChanges();

        return returnedPost;
    }

    public Task<Post?> DeletePostAsync(int id)
    {
        var returnedPost = postRepository.RemoveAsync(id);

        postRepository.SaveChangesAsync();

        return returnedPost;
    }

    public IEnumerable<Post>? GetAllPosts()
    {
        return postRepository.GetAll();
    }

    public Task<IEnumerable<Post>?> GetAllPostsAsync()
    {
        return postRepository.GetAllAsync();
    }

    public Post? GetPostById(int id)
    {
        return postRepository.GetById(id);
    }

    public Task<Post?> GetPostByIdAsync(int id)
    {
        return postRepository.GetByIdAsync(id);
    }

    public Post UpdatePost(Post post)
    {
        var updatedPost = postRepository.Update(post.Id, post);

        return updatedPost;
    }

    public async Task<Post> UpdatePostAsync(Post post)
    {
        var updatedPost = await postRepository.UpdateAsync(post.Id, post);

        return updatedPost;
    }
}