using Application.DTOs.Tag;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TagsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ITagService tagService;

    public TagsController(IMapper mapper, ITagService tagService)
    {
        this.mapper = mapper;
        this.tagService = tagService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTags()
    {
        var tags = await tagService.GetAllTagsAsync();

        var tagResponses = mapper.Map<IEnumerable<TagResponse>>(tags);

        return Ok(tagResponses);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetTagById(int id)
    {
        var tag = await tagService.GetTagByIdAsync(id);

        var tagResponse = mapper.Map<TagResponse>(tag);

        return Ok(tagResponse);
    }

    [HttpPost]
    public async Task<IActionResult> AddTag([FromBody] AddTagRequest addTagRequest)
    {
        var tag = mapper.Map<Tag>(addTagRequest);

        tag = await tagService.AddTagAsync(tag);

        if (tag != null)
        {
            var tagResponse = mapper.Map<TagResponse>(tag);

            return Ok(tagResponse);
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTag([FromBody] UpdateTagRequest updateTagRequest)
    {
        var tag = mapper.Map<Tag>(updateTagRequest);

        tag = await tagService.UpdateTagAsync(tag);

        if (tag != null)
        {
            var tagResponse = mapper.Map<TagResponse>(tag);

            return Ok(tagResponse);
        }

        return BadRequest();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        var tag = await tagService.DeleteTagAsync(id);

        if (tag != null)
        {
            var tagResponse = mapper.Map<TagResponse>(tag);

            return Ok(tagResponse);
        }

        return BadRequest();
    }
}
