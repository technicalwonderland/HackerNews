using HackerNews.Domain.Entities;
using HackerNews.Infrastructure.DAL.Data;

namespace HackerNews.Infrastructure.DAL.Mappers;

internal static class Extensions
{
    public static Story ToEntity(this StoryDbo storyDbo)
        => new(storyDbo.Title, storyDbo.Url, storyDbo.By, storyDbo.Time, storyDbo.Score, storyDbo.Kids.Length);
}