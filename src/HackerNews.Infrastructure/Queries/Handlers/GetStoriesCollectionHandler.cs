using HackerNews.Application.Abstractions;
using HackerNews.Application.DTO;
using HackerNews.Application.Queries;
using HackerNews.Infrastructure.DAL;
using HackerNews.Infrastructure.DAL.Cache;
using HackerNews.Infrastructure.Queries.Extensions;

namespace HackerNews.Infrastructure.Queries.Handlers;

internal sealed class GetStoriesCollectionHandler : IQueryHandler<GetStoriesCollection, PaginatedEntitiesDto<StoryDto>>
{
    private readonly IHackerNewsHttpClientContext _dataContext;
    private readonly IDataCache _dataCache;
    private const string CacheKey = nameof(GetStoriesCollection);

    public GetStoriesCollectionHandler(IHackerNewsHttpClientContext dataContext, IDataCache dataCache)
    {
        _dataContext = dataContext;
        _dataCache = dataCache;
    }

    public async Task<PaginatedEntitiesDto<StoryDto>> HandleAsync(GetStoriesCollection query)
    {
        var size = query.Size ?? 10;
        var key = $"{CacheKey}_{query.Size}";
        if (_dataCache.TryGetValue(key, out PaginatedEntitiesDto<StoryDto> cachedResult))
            return cachedResult;

        var stories = await _dataContext.GetStoriesAsync(size);
        cachedResult = stories.OrderByDescending(x => x.Score.Value).Select(x => x.ToDto())
            .ToPaginatedEntitiesDto(size);

        _dataCache.SaveValue(key, cachedResult);
        return cachedResult;
    }
}