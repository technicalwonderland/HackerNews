using System.Text.RegularExpressions;
using HackerNews.Domain.Exceptions;

namespace HackerNews.Domain.ValueObjects;

public sealed record URL
{
    private static readonly Regex Regex =
        new(
            @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)",
            RegexOptions.Compiled);

    public string Value { get; }

    public URL(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value))
            throw new InvalidUrlException(value);
        
        Value = value;
    }
    
    public static implicit operator string(URL url) => url.Value;
    public static implicit operator URL(string uri) => new(uri);
}