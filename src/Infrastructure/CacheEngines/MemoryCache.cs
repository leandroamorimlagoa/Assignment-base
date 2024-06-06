namespace Assignment.Infrastructure.CacheEngines
{
    public class MemoryCache<TValue>
    {
        private readonly Dictionary<string, MemoryCacheItem<TValue>> _cache = new();

        public void Set(string key, TValue value, TimeSpan expiration)
        {
            var cacheItem = new MemoryCacheItem<TValue>(value, DateTime.UtcNow.Add(expiration));
            _cache[key] = cacheItem;
        }

        public bool TryGetValue(string key, out TValue? value)
        {
            if (_cache.TryGetValue(key, out var cacheItem))
            {
                if (cacheItem.Expiration > DateTime.UtcNow)
                {
                    value = cacheItem.Value;
                    return true;
                }

                _cache.Remove(key);
            }

            value = default;
            return false;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Clear()
        {
            _cache.Clear();
        }
    }
}
