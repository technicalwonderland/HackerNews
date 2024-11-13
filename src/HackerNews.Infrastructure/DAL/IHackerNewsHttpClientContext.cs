using HackerNews.Domain.Entities;

namespace HackerNews.Infrastructure.DAL;

internal interface IHackerNewsHttpClientContext
{
    Task<IEnumerable<Story>> GetStoriesAsync(int number);
}