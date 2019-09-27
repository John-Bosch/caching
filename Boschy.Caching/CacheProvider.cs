namespace Boschy.Caching
{
    using System;

    public class CacheProvider : ICacheProvider
    {
        private readonly ICache cache;

        public CacheProvider()
        {
            // Only implementation is currently the default memory cache. This could be extended to 
            // use app fabric cache, disk cache or whatever by coding extra adapters 
            // and controlling which is loaded by config.
            this.cache = new DefaultMemoryCacheAdapter();
        }

        public CacheProvider(ICache cache)
        {
            this.cache = cache;
        }

        public T GetItem<T>(string cacheKey, DateTime expiryTime, Func<T> getDataFunc)
        {
            if (getDataFunc == null)
            {
                throw new ArgumentNullException("getDataFunc");
            }

            var data = this.GetItem<T>(cacheKey);

            if (data != null)
            {
                return data;
            }

            data = getDataFunc();
            this.cache.AddItem(cacheKey, expiryTime, data);

            return data;
        }

        public T GetItem<T>(string cacheKey, TimeSpan expirySpan, Func<T> getDataFunc)
        {
            if (getDataFunc == null)
            {
                throw new ArgumentNullException("getDataFunc");
            }

            var data = this.GetItem<T>(cacheKey);

            if (data != null)
            {
                return data;
            }

            data = getDataFunc();
            this.cache.AddItem(cacheKey, expirySpan, data);

            return data;
        }

        public T GetItem<T>(string cacheKey, Func<T> getDataFunc)
        {
            if (getDataFunc == null)
            {
                throw new ArgumentNullException("getDataFunc");
            }

            var data = this.GetItem<T>(cacheKey);

            if (data != null)
            {
                return data;
            }

            data = getDataFunc();
            this.cache.AddItem(cacheKey, data);

            return data;
        }

        public T GetItem<T>(string cacheKey)
        {
            return this.cache.GetItem<T>(cacheKey);
        }

        public bool AddItem<T>(string cacheKey, T data)
        {
            return this.cache.AddItem(cacheKey, data);
        }

        public bool AddItem<T>(string cacheKey, DateTime expiryTime, T data)
        {
            return this.cache.AddItem(cacheKey, expiryTime, data);
        }

        public bool AddItem<T>(string cacheKey, TimeSpan expirySpan, T data)
        {
            return this.cache.AddItem(cacheKey, expirySpan, data);
        }
        
        public void SetItem<T>(string cacheKey, T data)
        {
            this.cache.SetItem(cacheKey, data);
        }

        public void SetItem<T>(string cacheKey, DateTime expiryTime, T data)
        {
            this.cache.SetItem(cacheKey, expiryTime, data);
        }

        public void SetItem<T>(string cacheKey, TimeSpan expirySpan, T data)
        {
            this.cache.SetItem(cacheKey, expirySpan, data);
        }
    }
}