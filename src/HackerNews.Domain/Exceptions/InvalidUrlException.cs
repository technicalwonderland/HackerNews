namespace HackerNews.Domain.Exceptions;

public sealed class InvalidUrlException(string value):HackerNewsException($"{value} is not a valid URL!");