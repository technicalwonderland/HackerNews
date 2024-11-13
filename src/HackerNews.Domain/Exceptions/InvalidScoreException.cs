namespace HackerNews.Domain.Exceptions;

public sealed class InvalidScoreException(int score) : HackerNewsException($"{score} is not a valid score!");