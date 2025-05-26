using Application.IRepositories;
using Application.IServices;
using Domain.Entities;
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

    private Post InitiatePost(Post? post, Guid? employeeId, PostStatus? postStatus, int? views)
    {
        post.EmployeeId = employeeId.ToString();
        post.Status = postStatus;
        post.PublishDate = DateTime.Now;
        post.Views = views;

        return post;
    }

    public Post? AddPost(Post post, Guid employeeId)
    {
        post = InitiatePost(post, employeeId, PostStatus.Pending, 0);

        var returnedPpost = postRepository.Add(post);

        postRepository.SaveChanges();

        return returnedPpost;
    }

    public async Task<Post?> AddPostAsync(Post post, Guid employeeId)
    {
        post = InitiatePost(post, employeeId, PostStatus.Pending, 0);

        var returnedPpost = await postRepository.AddAsync(post);

        postRepository.SaveChanges();

        return returnedPpost;
    }

    public SeoMetadata? AddSEOMetaDataToPost(int postId, SeoMetadata seoMetadata)
    {
        seoMetadata.PostId = postId;

        var returnedSeoMetaData = seoMetaDataRepository.Add(seoMetadata);
        seoMetaDataRepository.SaveChanges();

        return returnedSeoMetaData;
    }

    public async Task<SeoMetadata?> AddSEOMetaDataToPostAsync(int postId, SeoMetadata seoMetadata)
    {
        seoMetadata.PostId = postId;

        var returnedSeoMetaData = await seoMetaDataRepository.AddAsync(seoMetadata);
        await seoMetaDataRepository.SaveChangesAsync();

        return returnedSeoMetaData;
    }

    public IEnumerable<Tag>? AddTagsToPost(int postId, IEnumerable<int> tagIds)
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

    public async Task<IEnumerable<Tag>?> AddTagsToPostAsync(int postId, IEnumerable<int> tagIds)
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

    public Post? DeletePost(int id, Guid employeeId)
    {
        //var returnedPost = postRepository.Remove(id);

        var deletedPost = postRepository.GetById(id);

        if(deletedPost == null) 
            return null;

        deletedPost = InitiatePost(deletedPost, employeeId, PostStatus.Deleted, deletedPost.Views);

        deletedPost = postRepository.Update(id, deletedPost);

        postRepository.SaveChanges();

        return deletedPost;
    }

    public async Task<Post?> DeletePostAsync(int id, Guid employeeId)
    {
        //var returnedPost = postRepository.RemoveAsync(id);

        var deletedPost = await postRepository.GetByIdAsync(id);

        if (deletedPost == null)
            return null;

        deletedPost = InitiatePost(deletedPost, employeeId, PostStatus.Deleted, deletedPost.Views);

        deletedPost = await postRepository.UpdateAsync(id, deletedPost);

        await postRepository.SaveChangesAsync();

        return deletedPost;
    }

    public SeoMetadata? DeleteSEOMetaDataFromPost(int postId, int seoMetaDataId)
    {
        var returnedSEOMetaData = seoMetaDataRepository.Remove(seoMetaDataId);

        if (returnedSEOMetaData == null)
            return null;

        postRepository.SaveChanges();

        return returnedSEOMetaData;
    }

    public async Task<SeoMetadata?> DeleteSEOMetaDataFromPostAsync(int postId, int seoMetaDataId)
    {
        var returnedSEOMetaData = seoMetaDataRepository.Remove(seoMetaDataId);
        await postRepository.SaveChangesAsync();

        if(returnedSEOMetaData == null)
            return null;

        return returnedSEOMetaData;
    }

    public IEnumerable<Tag>? DeleteTagsFromPost(int postId, IEnumerable<int> tagIds)
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

    public async Task<IEnumerable<Tag>?> DeleteTagsFromPostAsync(int postId, IEnumerable<int> tagIds)
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

    public Post? UpdatePost(int id, Post post, Guid employeeId)
    {
        post.Id = id;
        post = InitiatePost(post, employeeId, post.Status, post.Views);

        var updatedPost = postRepository.Update(id, post);

        postRepository.SaveChanges();

        return updatedPost;
    }

    public async Task<Post?> UpdatePostAsync(int id, Post post, Guid employeeId)
    {
        post.Id = id;
        post = InitiatePost(post, employeeId, post.Status, post.Views);

        var updatedPost = await postRepository.UpdateAsync(id, post);

        await postRepository.SaveChangesAsync();

        return updatedPost;
    }

    public SeoMetadata? UpdateSEOMetaDataToPost(int postId, SeoMetadata seoMetadata)
    {
        var returnedSEOMetaData = seoMetaDataRepository.Update(seoMetadata.Id, seoMetadata);
        seoMetaDataRepository.SaveChanges();

        return returnedSEOMetaData;
    }

    public async Task<SeoMetadata?> UpdateSEOMetaDataToPostAsync(int postId, SeoMetadata seoMetadata)
    {
        var returnedSEOMetaData = await seoMetaDataRepository.GetFirstOrDefaultAsync(x => x.PostId == postId);

        if (returnedSEOMetaData == null)
            return null;

        seoMetadata.Id = returnedSEOMetaData.Id;
        seoMetadata.PostId = postId;

        returnedSEOMetaData = await seoMetaDataRepository.UpdateAsync(seoMetadata.Id, seoMetadata);
        await seoMetaDataRepository.SaveChangesAsync();


        return returnedSEOMetaData;
    }
}