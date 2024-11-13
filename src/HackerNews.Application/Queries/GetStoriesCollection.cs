using HackerNews.Application.DTO;

namespace HackerNews.Application.Queries;

public class GetStoriesCollection : GetPaginatedEntities<StoryDto>;