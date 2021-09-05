using System;

namespace CacheLibrary
{
    /// <summary>
    /// Класс кеширования. Поддерживает стратегии LRU, MRU или кастомную
    /// </summary>
    /// <typeparam name="K">Тип ключа</typeparam>
    /// <typeparam name="V">Тип значения</typeparam>
    public class Cache<K, V>
    {
        private CacheItem<K, V>[] items;
        private int setsCount;
        private int associativity;
        private EvictionStrategy evictionStrategy;
        private Func<CacheItem<K, V>[], int, int, int> GetEvictionIndexCustom; // Необходим, если стратегия - Custom

        public Cache(int setsCount, int associativity, EvictionStrategy evictionStrategy = EvictionStrategy.LRU, Func<CacheItem<K, V>[], int, int, int> GetEvictionIndexCustom = null)
        {
            this.setsCount = setsCount;
            this.associativity = associativity;
            this.evictionStrategy = evictionStrategy;
            this.GetEvictionIndexCustom = GetEvictionIndexCustom;

            items = new CacheItem<K, V>[associativity * setsCount];

            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new CacheItem<K, V>();
            }
        }


        public void SetEvictionStrategy(EvictionStrategy evictionStrategy, Func<CacheItem<K,V>[], int, int, int> GetEvictionIndexCustom = null)
        {
            this.evictionStrategy = evictionStrategy;
            this.GetEvictionIndexCustom = GetEvictionIndexCustom;
        }

        /// <summary>
        /// Получить элемент кеша
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение (по ссылке)</param>
        /// <returns>Найден ли элемент</returns>
        public bool Get(K key, out V value)
        {
            int hash = getHash(key);
            int startIndex = getStartIndex(hash);
            int endIndex = getEndIndex(hash);

            int index = Find(key, startIndex, endIndex);

            if (index == -1)
            {
                value = default;
                return false;
            }

            Promote(index, startIndex, endIndex);

            value = items[index].Value;
            return true;
        }

        /// <summary>
        /// Поместить элемент в кеш
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public void Put(K key, V value)
        {
            int hash = getHash(key);
            int startIndex = getStartIndex(hash);
            int endIndex = getEndIndex(hash);

            int index = Find(key, startIndex, endIndex);

            if (index != -1)
            {
                Promote(index, startIndex, endIndex);
                items[index].Value = value;
                return;
            }

            index = GetEvictionIndex(items, startIndex, endIndex);

            items[index].Key = key;
            items[index].Value = value;
            items[index].Age = 0;
            Promote(index, startIndex, endIndex);
        }

        /// <summary>
        /// Очистить кеш
        /// </summary>
        public void Clear()
        {
            foreach (var item in items)
            {
                item.IsEmpty = true;
            }
        }

        private int Find(K key, int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (!items[i].IsEmpty && key.Equals(items[i].Key))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Отметить элемент как последний использованный
        /// </summary>
        private void Promote(int index, int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (items[i].IsEmpty) continue;

                if (items[index].IsEmpty || items[i].Age < items[index].Age)
                {
                    items[i].Age++;
                }
            }

            items[index].Age = 0;
            items[index].IsEmpty = false;
        }

        /// <summary>
        /// Выбрать элемент для вытеснения согласно выбранной стратегии
        /// </summary>
        /// <param name="items"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        private int GetEvictionIndex(CacheItem<K, V>[] items, int startIndex, int endIndex)
        {
            switch (evictionStrategy)
            {
                case EvictionStrategy.LRU:
                    return GetEvictionIndexLRU(items, startIndex, endIndex);
                case EvictionStrategy.MRU:
                    return GetEvictionIndexMRU(items, startIndex, endIndex);
                default:
                    return GetEvictionIndexCustom(items, startIndex, endIndex);
            }
        }

        /// <summary>
        /// Вытеснение LRU
        /// </summary>
        private int GetEvictionIndexLRU(CacheItem<K, V>[] items, int startIndex, int endIndex)
        {
            int maxAgeIndex = startIndex;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (items[i].IsEmpty)
                {
                    return i;
                }

                if (items[i].Age > items[maxAgeIndex].Age)
                {
                    maxAgeIndex = i;
                }
            }

            return maxAgeIndex;
        }

        /// <summary>
        /// Вытеснение MRU
        /// </summary>
        private int GetEvictionIndexMRU(CacheItem<K, V>[] items, int startIndex, int endIndex)
        {
            int minAgeIndex = startIndex;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (items[i].IsEmpty)
                {
                    return i;
                }

                if (items[i].Age == 0)
                {
                    minAgeIndex = i;
                }
            }

            return minAgeIndex;
        }

        private int getStartIndex(int hash)
        {
            return (hash % setsCount) * associativity;
        }

        private int getEndIndex(int hash)
        {
            return getStartIndex(hash) + associativity - 1;
        }

        private int getHash(K key)
        {
            int hash = key.GetHashCode();
            return hash < 0 ? -hash : hash;
        }
    }
}
