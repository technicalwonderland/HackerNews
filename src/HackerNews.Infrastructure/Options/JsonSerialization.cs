using System.Text.Json;

namespace HackerNews.Infrastructure.Options;

internal static class JsonSerialization
{
    internal static JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
}