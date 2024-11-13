using HackerNews.Application.DTO;
using HackerNews.Domain.Entities;
using HackerNews.Domain.ValueObjects;

namespace HackerNews.Infrastructure.Queries.Extensions;

public static class StoryExtensions
{
    public static StoryDto ToDto(this Story story)
    {
        return new()
        {
            Title = story.Title,
            Uri = story.Url,
            PostedBy = story.PostedBy,
            Time = story.Time,
            Score = story.Score,
            CommentCount = story.CommentCount
        };
    }
}