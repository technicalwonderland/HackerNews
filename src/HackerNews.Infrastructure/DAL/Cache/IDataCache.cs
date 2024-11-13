namespace HackerNews.Infrastructure.DAL.Cache;

public interface IDataCache
{
    bool TryGetValue<T>(string key, out T outValue);
    void SaveValue<T>(string key, T value);
}