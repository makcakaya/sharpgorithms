using System.Collections.Generic;

namespace Library
{
    public interface IBag<T> : IEnumerable<T>
    {
        void Add(T value);

        void Clear();
    }
}