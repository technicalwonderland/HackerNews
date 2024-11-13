namespace HackerNews.Domain.Exceptions;

public class InvalidCommentCountException(int value) : HackerNewsException($"Comment count: {value} is invalid!");