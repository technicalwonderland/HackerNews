using HackerNews.Infrastructure.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace HackerNews.Infrastructure.DAL.Cache;

internal sealed class MemoryDataCache : IDataCache
{
    private readonly IMemoryCache _memoryCache;
    private readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;
    public MemoryDataCache(IMemoryCache memoryCache, IOptions<CacheOptions> cacheOptions)
    {
        var options = cacheOptions.Value;
        _memoryCache = memoryCache;
        _memoryCacheEntryOptions = new MemoryCacheEntryOptions();
        _memoryCacheEntryOptions.SetAbsoluteExpiration(TimeSpan.FromSeconds(options.ExpirationInSeconds));
    }

    public bool TryGetValue<T>(string key, out T outValue)
    {
        var isSuccess = _memoryCache.TryGetValue(key, out T value);
        outValue = value;
        return isSuccess;
    }

    public void SaveValue<T>(string key, T value)
    {
        _memoryCache.Set(key, value, _memoryCacheEntryOptions);
    }
}