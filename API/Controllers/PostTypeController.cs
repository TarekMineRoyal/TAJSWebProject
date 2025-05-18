using Application.DTOs.PostType;
using Application.IServices;
using AutoMapper;
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
}
