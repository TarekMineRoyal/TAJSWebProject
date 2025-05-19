using Application.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TagsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ITagService tagService;

    public TagsController(IMapper mapper, ITagService tagService)
    {
        this.mapper = mapper;
        this.tagService = tagService;
    }


}
