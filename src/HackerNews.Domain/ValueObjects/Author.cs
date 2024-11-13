using HackerNews.Domain.Exceptions;

namespace HackerNews.Domain.ValueObjects;

public sealed record Author
{
    public string Value { get; }

    public Author(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName) || fullName.Length is < 3 or > 75)
            throw new InvalidAuthorNameException(fullName);

        Value = fullName;
    }
    
    public static implicit operator string(Author author) => author.Value;
    public static implicit operator Author(string authorFullName) => new Author(authorFullName);
}