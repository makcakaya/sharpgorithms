using System;

namespace Library
{
    public sealed class Queue<T> : IQueue<T>
    {
        private QueueNode<T> _first;
        private QueueNode<T> _last;

        public bool IsEmpty => Count == 0;

        public int Count { get; private set; }

        public void Enqueue(T value)
        {
            var newNode = new QueueNode<T> { Value = value, Next = null };
            if (_first == null)
            {
                _first = _last = newNode;
            }
            else
            {
                var oldLast = _last;
                _last = newNode;
                oldLast.Next = newNode;
            }
            Count++;
        }

        public T Dequeue()
        {
            if (_first == null)
            {
                throw new InvalidOperationException("Cannot dequeue on an empty queue.");
            }

            var value = _first.Value;
            _first = _first.Next;
            Count--;
            return value;
        }

        public T Peek()
        {
            return _first != null ? _first.Value : default(T);
        }

        private sealed class QueueNode<TValue>
        {
            public TValue Value { get; set; }
            public QueueNode<TValue> Next { get; set; }
        }
    }
}