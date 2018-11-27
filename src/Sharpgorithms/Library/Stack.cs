using System;

namespace Library
{
    public sealed class Stack<T> : IStack<T>
    {
        private Node<T> _last;

        public bool IsEmpty => Count == 0;

        public int Count { get; private set; } = 0;

        public T Pop()
        {
            if (_last == null) { throw new InvalidOperationException("Cannot Pop() while the stack is empty."); }

            var value = _last.Value;
            _last = _last.Previous;
            Count--;

            return value;
        }

        public void Push(T value)
        {
            var oldLast = _last;
            _last = new Node<T> { Value = value, Previous = oldLast };
            Count++;
        }

        public T Peek()
        {
            return _last != null ? _last.Value : default(T);
        }

        private sealed class Node<TValue>
        {
            public Node<TValue> Previous { get; set; }
            public TValue Value { get; set; }
        }
    }
}