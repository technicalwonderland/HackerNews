using HackerNews.Application.Abstractions;
using HackerNews.Application.DTO;

namespace HackerNews.Application.Queries;

public class GetPaginatedEntities<T> : IQuery<PaginatedEntitiesDto<T>>
{
    public int? Size { get; set; }
}