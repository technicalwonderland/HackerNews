namespace HackerNews.Domain.Exceptions;

public class InvalidAuthorNameException(string value) : HackerNewsException($"{value} is not a valid author name!");