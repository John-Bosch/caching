
namespace Boschy.Caching
{
    using System;
    using System.Linq;
    using System.Runtime.Caching;

    public class DefaultMemoryCacheAdapter : ICache
    {
        private readonly MemoryCache cache;

        public DefaultMemoryCacheAdapter()
        {
            this.cache = MemoryCache.Default;
        }

        public bool AddItem(string cacheKey, DateTime expiryTime, object data)
        {
            var policy = new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(expiryTime) };
            return this.cache.Add(cacheKey, data, policy);
        }

        public bool AddItem(string cacheKey, TimeSpan expirySpan, object data)
        {
            var item = new CacheItem(cacheKey, data);
            var policy = new CacheItemPolicy { SlidingExpiration = expirySpan };

            return this.cache.Add(item, policy);
        }

        public bool AddItem(string cacheKey, object data)
        {
            var item = new CacheItem(cacheKey, data);
            var policy = new CacheItemPolicy { AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration };

            return this.cache.Add(item, policy);
        }

        public void SetItem(string cacheKey, DateTime expiryTime, object data)
        {
            var policy = new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(expiryTime) };
            this.cache.Set(cacheKey, data, policy);
        }

        public void SetItem(string cacheKey, TimeSpan expirySpan, object data)
        {
            var item = new CacheItem(cacheKey, data);
            var policy = new CacheItemPolicy { SlidingExpiration = expirySpan };

            this.cache.Set(item, policy);
        }

        public void SetItem(string cacheKey, object data)
        {
            var item = new CacheItem(cacheKey, data);
            var policy = new CacheItemPolicy { AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration };

            this.cache.Set(item, policy);
        }

        public void ClearAll()
        {
            this.cache.ToList().ForEach(i => this.cache.Remove(i.Key));
        }

        public T GetItem<T>(string cacheKey)
        {
            var data = (T)this.cache.Get(cacheKey);
            return data;
        }

        public void RemoveItem(string cacheKey)
        {
            this.cache.Remove(cacheKey);
        }
    }
}