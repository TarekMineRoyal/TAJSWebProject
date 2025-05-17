using Application.DTOs;
using Application.IServices;
using AutoMapper;
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
        var posts = postService.GetPostByIdAsync(id);

        if(posts == null)
            return NotFound();

        var postsResponse = mapper.Map<PostResponse>(posts);

        return Ok(postsResponse);
    }


}
