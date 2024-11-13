using HackerNews.Domain.Exceptions;

namespace HackerNews.Domain.ValueObjects;

public sealed record EventTime
{
    public DateTimeOffset Value { get; }

    public EventTime(long value)
    {
        DateTimeOffset dateTime;
        try
        {
            dateTime = DateTimeOffset.FromUnixTimeSeconds(value);
        }
        catch (Exception)
        {
            throw new InvalidTimeException(value);
        }
        Value = dateTime;
    }
    
    public static implicit operator DateTimeOffset(EventTime eventTime) => eventTime.Value;
    public static implicit operator EventTime(long eventTime) => new (eventTime);
    public static implicit operator long(EventTime eventTime) => eventTime.Value.ToUnixTimeSeconds();
    
    public override string ToString() => Value.ToString("o");
}