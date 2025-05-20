using Application.DTOs.Tag;
using Application.IServices;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]

public class SEOMetaDataController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ISEOMetaDataService seoMetaDataService;

    public SEOMetaDataController(IMapper mapper, ISEOMetaDataService seoMetaDataService)
    {
        this.mapper = mapper;
        this.seoMetaDataService = seoMetaDataService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSEOMetaData()
    {
        var seoMetaData = await seoMetaDataService.GetAllSEOMetaDataAsync();

        var seoMetaDataResponses = mapper.Map<IEnumerable<TagResponse>>(seoMetaData);

        return Ok(seoMetaDataResponses);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetSEOSEOMetaDataById(int id)
    {
        var seoMetaData = await seoMetaDataService.GetSEOMetaDataByIdAsync(id);

        var seoMetaDataResponse = mapper.Map<TagResponse>(seoMetaData);

        return Ok(seoMetaDataResponse);
    }

    [HttpPost]
    public async Task<IActionResult> AddSEOMetaData([FromBody] AddTagRequest addTagRequest)
    {
        var seoMetaData = mapper.Map<SeoMetadata>(addTagRequest);

        seoMetaData = await seoMetaDataService.AddSEOMetaDataAsync(seoMetaData);

        if (seoMetaData != null)
        {
            var seoMetaDataResponse = mapper.Map<TagResponse>(seoMetaData);

            return Ok(seoMetaDataResponse);
        }

        return BadRequest();
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateSEOMetaData(int id, [FromBody] UpdateTagRequest updateTagRequest)
    {
        var seoMetaData = mapper.Map<SeoMetadata>(updateTagRequest);

        seoMetaData = await seoMetaDataService.UpdateSEOMetaDataAsync(id, seoMetaData);

        if (seoMetaData != null)
        {
            var seoMetaDataResponse = mapper.Map<TagResponse>(seoMetaData);

            return Ok(seoMetaDataResponse);
        }

        return BadRequest();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteSEOMetaData(int id)
    {
        var seoMetaData = await seoMetaDataService.DeleteSEOMetaDataAsync(id);

        if (seoMetaData != null)
        {
            var seoMetaDataResponse = mapper.Map<TagResponse>(seoMetaData);

            return Ok(seoMetaDataResponse);
        }

        return BadRequest();
    }
}
