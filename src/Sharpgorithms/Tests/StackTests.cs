using Library;
using System;
using Xunit;

namespace Tests
{
    public sealed class StackTests
    {
        [Fact]
        public void Can_Create()
        {
            new Stack<int>();
        }

        [Fact]
        public void Count_Returns_Zero_While_Empty()
        {
            Assert.Equal(0, new Stack<int>().Count);
        }

        [Fact]
        public void IsEmpty_Returns_False_If_Not_Empty()
        {
            var stack = new Stack<int>();
            stack.Push(10);

            Assert.False(stack.IsEmpty);
        }

        [Fact]
        public void IsEmpty_Returns_True_While_Empty()
        {
            Assert.True(new Stack<int>().IsEmpty);
        }

        [Fact]
        public void Can_Push()
        {
            new Stack<int>().Push(1);
        }

        [Fact]
        public void Push_Inserts_Item()
        {
            var stack = new Stack<int>();
            stack.Push(1);

            Assert.False(stack.IsEmpty);
            Assert.Equal(1, stack.Count);
        }

        [Fact]
        public void Can_Pop()
        {
            var stack = new Stack<int>();
            stack.Push(1);

            stack.Pop();
        }

        [Fact]
        public void Pop_Returns_From_End()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Pop());
        }

        [Fact]
        public void Pop_Throws_If_Empty()
        {
            Assert.Throws<InvalidOperationException>(() => new Stack<int>().Pop());
        }

        [Fact]
        public void Pop_Removes_Item_From_End()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var count = stack.Count;

            stack.Pop();

            Assert.Equal(count - 1, stack.Count);
        }

        [Fact]
        public void Peek_Returns_Default_If_Empty()
        {
            var stack = new Stack<int>();

            Assert.Equal(default(int), stack.Peek());
        }

        [Fact]
        public void Peek_Returns_Item_From_End()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);

            Assert.Equal(7, stack.Peek());
        }

        [Fact]
        public void Peek_Does_Not_Remove_Item()
        {
            var stack = new Stack<int>();
            stack.Push(1);

            var valuePeek = stack.Peek();

            Assert.Equal(1, stack.Count);

            var value = stack.Pop();

            Assert.Equal(value, valuePeek);
        }
    }
}