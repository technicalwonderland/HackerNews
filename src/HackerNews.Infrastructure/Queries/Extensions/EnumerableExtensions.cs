using HackerNews.Application.DTO;

namespace HackerNews.Infrastructure.Queries.Extensions;

public static class EnumerableExtensions
{
    public static PaginatedEntitiesDto<T> ToPaginatedEntitiesDto<T>(this IEnumerable<T> source, int size) =>
        new() { Entities = source, Size = size };
}