using HackerNews.Domain.Exceptions;

namespace HackerNews.Domain.ValueObjects;

public sealed record Score
{
    public int Value { get; }

    public Score(int value)
    {
        if (value < 0)
            throw new InvalidScoreException(value);
        Value = value;
    }
    
    public static implicit operator int(Score score) => score.Value;
    public static implicit operator Score(int score) => new (score);
}