namespace HackerNews.Infrastructure.DAL.Data;

internal sealed record StoryDbo
{
    public required string Title { get; init; }
    public required string Url { get; init; }
    public required string By {get;  init; }
    public required long Time { get; init; }
    public required int Score { get; init; }
    public required int[] Kids { get; init; }
}