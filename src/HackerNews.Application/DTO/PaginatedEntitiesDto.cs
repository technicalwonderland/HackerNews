namespace HackerNews.Application.DTO;

public class PaginatedEntitiesDto<T>
{
    public int Size { get; set; }
    public IEnumerable<T> Entities { get; set; }
}