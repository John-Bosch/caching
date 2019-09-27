
namespace Boschy.Caching
{
    using System;
    
    public interface ICacheProvider
    {
        T GetItem<T>(string cacheKey, DateTime expiryTime, Func<T> getDataFunc);

        T GetItem<T>(string cacheKey, TimeSpan expirySpan, Func<T> getDataFunc);
        
        T GetItem<T>(string cacheKey, Func<T> getDataFunc);

        T GetItem<T>(string cacheKey);
        
        /// <summary>
        /// Returns true if the item is added. Returns false if the item already exists
        /// </summary>
        bool AddItem<T>(string cacheKey, T data);

        bool AddItem<T>(string cacheKey, DateTime expiryTime, T data);

        bool AddItem<T>(string cacheKey, TimeSpan expirySpan, T data);
        
        /// <summary>
        /// If the specified entry does not exist, it is created. If the specified entry exists, it is updated.
        /// </summary>        
        void SetItem<T>(string cacheKey, T data);

        void SetItem<T>(string cacheKey, DateTime expiryTime, T data);

        void SetItem<T>(string cacheKey, TimeSpan expirySpan, T data);
    }
}