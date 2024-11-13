using System.Net.Http.Json;
using HackerNews.Domain.Entities;
using HackerNews.Infrastructure.DAL.Data;
using HackerNews.Infrastructure.DAL.Mappers;
using HackerNews.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace HackerNews.Infrastructure.DAL;

internal class HackerNewsHttpClientContext : IHackerNewsHttpClientContext
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOptions<DataOptions> _dataOptions;

    public HackerNewsHttpClientContext(IHttpClientFactory httpClientFactory, IOptions<DataOptions> dataOptions)
    {
        _httpClientFactory = httpClientFactory;
        _dataOptions = dataOptions;
    }

    public async Task<IEnumerable<Story>> GetStoriesAsync(int numberOfStories)
    {
        var client = _httpClientFactory.CreateClient();
        var storyIds = await client.GetFromJsonAsync<int[]>(_dataOptions.Value.StoriesCollectionURI);
        if (storyIds == null)
            return Array.Empty<Story>();

        numberOfStories = Math.Min(numberOfStories, storyIds.Length);
        var tasks = new List<Task<StoryDbo>>(numberOfStories);
        for (var i = 0; i < numberOfStories; i++)
        {
            tasks.Add(client.GetFromJsonAsync<StoryDbo>(CreateStoryUrl(storyIds[i]), JsonSerialization.Options));
        }

        var stories = await Task.WhenAll(tasks);
        return stories.Select(x=>x.ToEntity());
    }

    private string CreateStoryUrl(int storyId) => $"{_dataOptions.Value.StoryURI}{storyId}.json";
}