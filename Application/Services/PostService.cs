using Application.IRepositories;
using Application.IServices;
using Domain.Entities.AppEntities;

namespace Application.Services;

public class PostService : IPostService
{
    private readonly IGenericRepository<Post> postRepository;
    private readonly IGenericRepository<SeoMetadata> seoMetaDataRepository;
    private readonly IGenericRepository<PostTag> postTagRepository;
    private readonly IGenericRepository<Tag> tagRepository;

    public PostService(IGenericRepository<Post> postRepository, IGenericRepository<SeoMetadata> seoMetaDataRepository,
        IGenericRepository<PostTag> postTagRepository, IGenericRepository<Tag> tagRepository)
    {
        this.postRepository = postRepository;
        this.seoMetaDataRepository = seoMetaDataRepository;
        this.postTagRepository = postTagRepository;
        this.tagRepository = tagRepository;
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

    public SeoMetadata AddSEOMetaDataToPost(int postId, SeoMetadata seoMetadata)
    {
        seoMetadata.PostId = postId;

        var returnedSeoMetaData = seoMetaDataRepository.Add(seoMetadata);
        seoMetaDataRepository.SaveChanges();

        return returnedSeoMetaData;
    }

    public async Task<SeoMetadata> AddSEOMetaDataToPostAsync(int postId, SeoMetadata seoMetadata)
    {
        seoMetadata.PostId = postId;

        var returnedSeoMetaData = await seoMetaDataRepository.AddAsync(seoMetadata);
        await seoMetaDataRepository.SaveChangesAsync();

        return returnedSeoMetaData;
    }

    public IEnumerable<Tag> AddTagsToPost(int postId, IEnumerable<int> tagIds)
    {
        var postTags = new List<PostTag>();

        foreach (var tagId in tagIds)
        {
            var postTag = new PostTag()
            {
                TagId = tagId,
                PostId = postId
            };

            postTags.Add(postTag);
        }

        postTagRepository.AddRange(postTags);
        postTagRepository.SaveChanges();

        var tags = new List<Tag>();

        foreach(var tagId in tagIds)
        {
            tags.Add(tagRepository.GetById(tagId));
        }

        return tags;
    }

    public async Task<IEnumerable<Tag>> AddTagsToPostAsync(int postId, IEnumerable<int> tagIds)
    {
        var postTags = new List<PostTag>();

        foreach (var tagId in tagIds)
        {
            var postTag = new PostTag()
            {
                TagId = tagId,
                PostId = postId
            };

            postTags.Add(postTag);
        }

        await postTagRepository.AddRangeAsync(postTags);
        await postTagRepository.SaveChangesAsync();

        var tags = new List<Tag>();

        foreach (var tagId in tagIds)
        {
            tags.Add(await tagRepository.GetByIdAsync(tagId));
        }

        return tags;
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

    public SeoMetadata DeleteSEOMetaDataFromPost(int postId, int seoMetaDataId)
    {
        var returnedSEOMetaData = seoMetaDataRepository.Remove(seoMetaDataId);
        postRepository.SaveChanges();

        return returnedSEOMetaData;
    }

    public async Task<SeoMetadata> DeleteSEOMetaDataFromPostAsync(int postId, int seoMetaDataId)
    {
        var returnedSEOMetaData = seoMetaDataRepository.Remove(seoMetaDataId);
        await postRepository.SaveChangesAsync();

        return returnedSEOMetaData;
    }

    public IEnumerable<Tag> DeleteTagsFromPost(int postId, IEnumerable<int> tagIds)
    {
        var postTags = new List<PostTag>();

        foreach (var tagId in tagIds)
        {
            postTags.Add(postTagRepository.GetFirstOrDefault(x => x.PostId == postId && x.TagId == tagId));
        }

        postTagRepository.DeleteRange(postTags);
        postTagRepository.SaveChanges();

        var tags = new List<Tag>();

        foreach (var tagId in tagIds)
        {
            tags.Add(tagRepository.GetById(tagId));
        }

        return tags;
    }

    public async Task<IEnumerable<Tag>> DeleteTagsFromPostAsync(int postId, IEnumerable<int> tagIds)
    {
        var postTags = new List<PostTag>();

        foreach (var tagId in tagIds)
        {
            postTags.Add(await postTagRepository.GetFirstOrDefaultAsync(x => x.PostId == postId && x.TagId == tagId));
        }

        postTagRepository.DeleteRange(postTags);
        postTagRepository.SaveChanges();

        var tags = new List<Tag>();

        foreach (var tagId in tagIds)
        {
            tags.Add(await tagRepository.GetByIdAsync(tagId));
        }

        return tags;
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

    public Post UpdatePost(int id, Post post)
    {
        var updatedPost = postRepository.Update(id, post);

        return updatedPost;
    }

    public async Task<Post> UpdatePostAsync(int id, Post post)
    {
        var updatedPost = await postRepository.UpdateAsync(id, post);

        return updatedPost;
    }

    public SeoMetadata UpdateSEOMetaDataToPost(int postId, SeoMetadata seoMetadata)
    {
        var returnedSEOMetaData = seoMetaDataRepository.Update(seoMetadata.Id, seoMetadata);
        seoMetaDataRepository.SaveChanges();

        return returnedSEOMetaData;
    }

    public Task<SeoMetadata> UpdateSEOMetaDataToPostAsync(int postId, SeoMetadata seoMetadata)
    {
        var returnedSEOMetaData = seoMetaDataRepository.UpdateAsync(seoMetadata.Id, seoMetadata);
        seoMetaDataRepository.SaveChangesAsync();

        return returnedSEOMetaData;
    }
}