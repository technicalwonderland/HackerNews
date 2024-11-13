using HackerNews.Domain.Exceptions;

namespace HackerNews.Domain.ValueObjects;

public sealed record Title
{
    public string Value { get; }

    public Title(string title)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length is < 3 or > 255)
            throw new InvalidTitleException(title);
        Value = title;
    }

    public static implicit operator string(Title title) => title.Value;
    public static implicit operator Title(string title) => new(title);
}