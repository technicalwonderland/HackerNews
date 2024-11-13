using HackerNews.Domain.Exceptions;

namespace HackerNews.Domain.ValueObjects;

public sealed record CommentCount
{
    public int Value { get; }

    public CommentCount(int value)
    {
        if (value < 0)
            throw new InvalidCommentCountException(value);
        
        Value = value;
    }

    public static implicit operator int(CommentCount commentCount) => commentCount.Value;
    public static implicit operator CommentCount(int value) => new (value);
}