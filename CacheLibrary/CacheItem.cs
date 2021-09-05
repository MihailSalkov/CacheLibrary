namespace CacheLibrary
{
    public class CacheItem<K, V>
    {
        public K Key;
        public V Value;
        public ushort Age;
        public bool IsEmpty;

        public CacheItem()
        {
            IsEmpty = true;
        }
    }
}
