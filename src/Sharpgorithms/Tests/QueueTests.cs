using Library;
using System;
using Xunit;

namespace Tests
{
    public sealed class QueueTests
    {
        [Fact]
        public void Can_Create()
        {
            new Queue<int>();
        }

        [Fact]
        public void Can_Enqueue()
        {
            new Queue<int>().Enqueue(1);
        }

        [Fact]
        public void Can_Dequeue()
        {
            var queue = new Queue<int>();
            queue.Enqueue(3);
            queue.Dequeue();
        }

        [Fact]
        public void Dequeue_Returns_First_Item()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
        }

        [Fact]
        public void Dequeue_Throws_If_Empty()
        {
            Assert.Throws<InvalidOperationException>(() => new Queue<int>().Dequeue());
        }

        [Fact]
        public void Count_Returns_Number_Of_Items()
        {
            var queue = new Queue<int>();

            Assert.Equal(0, queue.Count);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(3, queue.Count);
        }

        [Fact]
        public void IsEmpty_Returns_True_If_Empty()
        {
            Assert.True(new Queue<int>().IsEmpty);
        }

        [Fact]
        public void IsEmpty_Returns_False_If_Not_Empty()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);

            Assert.False(queue.IsEmpty);
        }

        [Fact]
        public void Peek_Returns_Default_If_Empty()
        {
            var queue = new Queue<int>();
            Assert.Equal(default(int), queue.Peek());
        }

        [Fact]
        public void Peek_Returns_First_Item()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void Peek_Does_Not_Remove_Item()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var peekValue = queue.Peek();

            Assert.Equal(3, queue.Count);

            var value = queue.Dequeue();

            Assert.Equal(1, peekValue);
            Assert.Equal(peekValue, value);
        }
    }
}