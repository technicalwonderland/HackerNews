namespace HackerNews.Domain.Exceptions;

public class InvalidTimeException(long value) : HackerNewsException($"Time value: {value} is invalid!");