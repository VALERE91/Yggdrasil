using System.Collections.Concurrent;

namespace Yggdrasil.Utils
{
    public class ObjectPool<T> where T:IPoolObject, new()
    {
        private ConcurrentBag<T> m_pool;

        public int Count
        {
            get
            {
                return m_pool.Count;
            }
        }

        public ObjectPool(int capacity)
        {
            m_pool = new ConcurrentBag<T>();
            for(int i = 0; i < capacity; ++i)
            {
                m_pool.Add(new T());
            }
        }

        public bool TryGet(out T elem)
        {
            return m_pool.TryTake(out elem);
        }

        public void Release(T value)
        {
            value.Reset();
            m_pool.Add(value);
        }
    }
}