namespace Assignment.Infrastructure.CacheEngines
{
    internal class MemoryCacheItem<TValue>
    {
        public MemoryCacheItem(TValue value, DateTime expiration)
        {
            Value = value;
            Expiration = expiration;
        }

        public TValue Value { get; }
        public DateTime Expiration { get; }
    }
}
