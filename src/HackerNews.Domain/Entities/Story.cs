using HackerNews.Domain.ValueObjects;

namespace HackerNews.Domain.Entities;

public class Story
{
    public Title Title { get; private set; }
    public URL Url { get; private set; }
    public Author PostedBy { get; private set; }
    public EventTime Time { get; private set; }
    public Score Score { get; private set; }
    public CommentCount CommentCount { get; private set; }

    private Story()
    {
    }

    public Story(Title title, URL url, Author postedBy, EventTime time, Score score, CommentCount commentCount)
    {
        Title = title;
        Url = url;
        PostedBy = postedBy;
        Time = time;
        Score = score;
        CommentCount = commentCount;
    }
}