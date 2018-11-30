using System;

namespace Library
{
    public sealed class BinaryHeap<T> where T : IComparable<T>
    {
        private readonly T[] _array;
        private int _count = 0;
        private readonly Func<T, T, bool> _comparator;

        public bool IsEmpty => _count == 0;

        public BinaryHeap(HeapType type, int size)
        {
            _comparator = type == HeapType.Max ?
                new Func<T, T, bool>((k1, k2) => k1.CompareTo(k2) > 0) :
                new Func<T, T, bool>((k1, k2) => k1.CompareTo(k2) < 0);

            _array = new T[size];
        }

        public void Add(T key)
        {
            var index = _count++ + 1;
            _array[index] = key;
            Swim(index);
        }

        public T Remove()
        {
            if (IsEmpty) { throw new InvalidOperationException(); }

            var key = _array[1];
            _array[1] = _array[_count];
            _array[_count--] = default(T);
            Sink();

            return key;
        }

        public void Print()
        {
            for (var i = 1; i < _count; i++)
            {
                Console.Write($"{_array[i]} ");
            }
            Console.WriteLine();
        }

        private void Sink()
        {
            var index = 1;
            while (index * 2 < _count)
            {
                var leftIndex = index * 2;
                var rightIndex = leftIndex + 1;
                var swapIndex = _comparator(_array[leftIndex], _array[rightIndex]) ? leftIndex : rightIndex;

                if (_comparator(_array[swapIndex], _array[index]))
                {
                    Swap(index, swapIndex);
                    index = swapIndex;
                }
                else
                {
                    return;
                }
            }
        }

        private void Swim(int index)
        {
            var key = _array[index];
            while (index > 1)
            {
                var parentIndex = index / 2;
                var parentKey = _array[parentIndex];
                if (_comparator(key, parentKey))
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else
                {
                    return;
                }
            }
        }

        private void Swap(int index1, int index2)
        {
            var temp = _array[index1];
            _array[index1] = _array[index2];
            _array[index2] = temp;
        }
    }

    public enum HeapType
    {
        Min,
        Max
    }
}