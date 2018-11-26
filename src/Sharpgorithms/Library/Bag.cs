using System.Collections;
using System.Collections.Generic;

namespace Library
{
    public sealed class Bag<T> : IBag<T>
    {
        private BagNode<T> _first;

        public int Count { get; private set; } = 0;

        public bool IsEmpty => Count == 0;

        public void Add(T value)
        {
            var oldFirst = _first;
            _first = new BagNode<T> { Next = oldFirst, Value = value };
            Count++;
        }

        public void Clear()
        {
            _first = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BagEnumerator<T>(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new BagEnumerator<T>(_first);
        }

        private sealed class BagNode<TValue>
        {
            public BagNode<TValue> Next { get; set; }
            public T Value { get; set; }
        }

        private sealed class BagEnumerator<TValue> : IEnumerator<T>
        {
            private readonly BagNode<TValue> _first;
            private bool _setup = false;
            private BagNode<TValue> _current = null;

            public BagEnumerator(BagNode<TValue> first)
            {
                _first = first;
            }

            public T Current => _current != null ? _current.Value : default(T);

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _current = null;
            }

            public bool MoveNext()
            {
                if (!_setup)
                {
                    _setup = true;
                    _current = _first;
                    return _current != null;
                }

                _current = _current?.Next;
                return _current != null;
            }

            public void Reset()
            {
                _current = _first;
            }
        }
    }
}