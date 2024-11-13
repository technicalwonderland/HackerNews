namespace HackerNews.Domain.Exceptions;

public sealed class InvalidTitleException(string title) :HackerNewsException($"{title} is not a valid title.");