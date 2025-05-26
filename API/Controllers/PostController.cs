using Application.DTOs.Post;
using Application.DTOs.SEOMetaData;
using Application.DTOs.Tag;
using Application.IServices;
using AutoMapper;
using Azure;
using Domain.Entities.AppEntities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : Controller
{
    private readonly IMapper mapper;
    private readonly IPostService postService;

    public PostController(IMapper mapper, IPostService postService)
    {
        this.mapper = mapper;
        this.postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await postService.GetAllPostsAsync();

        var postsResponse = mapper.Map<IEnumerable<PostResponse>>(posts);

        return Ok(postsResponse);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var posts = await postService.GetPostByIdAsync(id);

        if(posts == null)
            return NotFound();

        var postsResponse = mapper.Map<PostResponse>(posts);

        return Ok(postsResponse);
    }

    [HttpPost]
    public async Task<IActionResult> AddPost([FromBody] AddPostRequest addPostRequest)
    {
        var post = mapper.Map<Post>(addPostRequest);

        post = await postService.AddPostAsync(post);

        if (post == null)
            return BadRequest();


        var postResponse = mapper.Map<PostResponse>(post);
        return Ok(postResponse);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await postService.DeletePostAsync(id);
        var postResponse = mapper.Map<PostResponse>(post);

        return Ok(postResponse);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] UpdatePostRequest updatePostRequest)
    {
        var post = mapper.Map<Post>(updatePostRequest);

        var updatePost = await postService.UpdatePostAsync(id, post);

        if(updatePost == null)
            return BadRequest();

        var postResponse = mapper.Map<PostResponse>(post);
        return Ok(postResponse);
    }

    [HttpPost]
    [Route("{postId:int}/seoMetaData")]
    public async Task<IActionResult> AddSEOMetaDataToPost(int postId, AddSEOMetaDataToPostRequest addSEOMetaDataToPostRequest)
    {
        var seoMetaData = mapper.Map<SeoMetadata>(addSEOMetaDataToPostRequest);

        seoMetaData = await postService.AddSEOMetaDataToPostAsync(postId, seoMetaData);

        var seoMetaDataResponse = mapper.Map<SEOMetaDataResponse>(seoMetaData);

        return Ok(seoMetaDataResponse);
    }

    [HttpPut]
    [Route("{postId:int}/seoMetaData")]
    public async Task<IActionResult> UpdateSEOMetaDataToPost(int postId, UpdateSeoMetaDataToPostRequest updateSEOMetaDataToPostRequest)
    {
        var seoMetaData = mapper.Map<SeoMetadata>(updateSEOMetaDataToPostRequest);

        seoMetaData = await postService.UpdateSEOMetaDataToPostAsync(postId, seoMetaData);

        var seoMetaDataResponse = mapper.Map<SEOMetaDataResponse>(seoMetaData);

        return Ok(seoMetaDataResponse);
    }

    [HttpDelete]
    [Route("{postId:int}/seoMetaData")]
    public async Task<IActionResult> DeleteSEOMetaDataFromPost(int postId, int seoMetaDataId)
    { 
        var seoMetaData = await postService.DeleteSEOMetaDataFromPostAsync(postId, seoMetaDataId);

        var seoMetaDataResponse = mapper.Map<SEOMetaDataResponse>(seoMetaData);

        return Ok(seoMetaDataResponse);
    }

    [HttpPost]
    [Route("{postId:Guid}/tags")]
    public async Task<IActionResult> AddTagsToPost(int postId, AddTagsToPostRequest addTagsToPostRequest)
    {
        var tag = await postService.AddTagsToPostAsync(postId, addTagsToPostRequest.Ids);

        var tagResponse = mapper.Map<IEnumerable<TagResponse>>(tag);

        return Ok(tagResponse);
    }

    [HttpDelete]
    [Route("{postId:int}/tags")]
    public async Task<IActionResult> DeleteTagsFromPost(int postId, DeleteTagsFromPostRequest deleteTagsFromPostRequest)
    {
        var tag = await postService.DeleteTagsFromPostAsync(postId, deleteTagsFromPostRequest.Ids);

        var tagResponse = mapper.Map<IEnumerable<TagResponse>>(tag);

        return Ok(tagResponse);
    }
}
