using Microsoft.Extensions.Caching.Memory;
using TDD_Architecture.Infra.Singletons.Cache.Interfaces;

namespace TDD_Architecture.Infra.Singletons.Cache
{
    public class CacheService : ICacheService
    {
        private readonly MemoryCache _cache;

        public CacheService()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public T? Get<T>(string key)
        {
            _cache.TryGetValue(key, out T value);
            return value;
        }

        public void Set<T>(string key, T value, TimeSpan expiration)
        {
            _cache.Set(key, value, expiration);
        }
    }
}
