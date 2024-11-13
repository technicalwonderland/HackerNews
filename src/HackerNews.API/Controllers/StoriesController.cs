using HackerNews.Application.Abstractions;
using HackerNews.Application.DTO;
using HackerNews.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HackerNews.API.Controllers;

[ApiController]
[Route("stories")]
public class StoriesController(
    IQueryHandler<GetStoriesCollection, PaginatedEntitiesDto<StoryDto>> getStoriesQueryHandler)
    : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] GetStoriesCollection getStories)
    {
        var result = await getStoriesQueryHandler.HandleAsync(getStories);
        return Ok(result.Entities);
    }
}