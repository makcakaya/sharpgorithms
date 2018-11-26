using System.Collections.Generic;

namespace Library
{
    public interface IBag<T> : IEnumerable<T>, ICountableCollection
    {
        void Add(T value);

        void Clear();
    }
}