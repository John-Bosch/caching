
namespace Boschy.Caching
{
    using System;

    /// <summary>
    /// The Cache interface.
    /// </summary>
    public interface ICache
    {
        bool AddItem(string cacheKey, DateTime expiryTime, object data);

        bool AddItem(string cacheKey, TimeSpan expirySpan, object data);

        bool AddItem(string cacheKey, object data);

        void SetItem(string cacheKey, DateTime expiryTime, object data);

        void SetItem(string cacheKey, TimeSpan expirySpan, object data);

        void SetItem(string cacheKey, object data);

        void ClearAll();

        T GetItem<T>(string cacheKey);

        void RemoveItem(string cacheKey);
    }
}