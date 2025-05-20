using Application.DTOs.PostType;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PostTypeController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IPostTypeService postTypeService;

    public PostTypeController(IMapper mapper, IPostTypeService postTypeService)
    {
        this.mapper = mapper;
        this.postTypeService = postTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPostTypes()
    {
        var postTypes = await postTypeService.GetAllPostTypesAsync();

        var postTypeResponses = mapper.Map<IEnumerable<PostTypeResponse>>(postTypes);

        return Ok(postTypeResponses);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetPostTypeById(int id)
    {
        var postType = await postTypeService.GetPostTypeByIdAsync(id);

        var postTypeResponse = mapper.Map<PostTypeResponse>(postType);

        return Ok(postTypeResponse);
    }

    [HttpPost]
    public async Task<IActionResult> AddPostType([FromBody] AddPostTypeRequest addPostTypeRequest)
    {
        var postType = mapper.Map<PostType>(addPostTypeRequest);

        postType = await postTypeService.AddPostTypeAsync(postType);

        if(postType != null)
        {
            var postTypeResponse = mapper.Map<PostTypeResponse>(postType);

            return Ok(postTypeResponse);
        }

        return BadRequest();
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdatePostType(int id, [FromBody] UpdatePostTypeRequest updatePostTypeRequest)
    {
        var postType = mapper.Map<PostType>(updatePostTypeRequest);

        postType = await postTypeService.UpdatePostTypeAsync(id, postType);

        if (postType != null)
        {
            var postTypeResponse = mapper.Map<PostTypeResponse>(postType);

            return Ok(postTypeResponse);
        }

        return BadRequest();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeletePostType(int id)
    {
        var postType = await postTypeService.DeletePostTypeAsync(id);

        if (postType != null)
        {
            var postTypeResponse = mapper.Map<PostTypeResponse>(postType);

            return Ok(postTypeResponse);
        }

        return BadRequest();
    }
}
