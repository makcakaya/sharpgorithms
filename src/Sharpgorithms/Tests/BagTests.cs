using Library;
using Xunit;

namespace Tests
{
    public sealed class BagTests
    {
        [Fact]
        public void Can_Create()
        {
            new Bag<int>();
        }

        [Fact]
        public void Can_Add()
        {
            new Bag<int>().Add(10);
        }

        [Fact]
        public void Can_Add_Multiple_Times()
        {
            var bag = new Bag<int>();
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);
        }

        [Fact]
        public void Can_Enumerate_While_Empty()
        {
            var bag = new Bag<int>();
            foreach (var item in bag)
            {
            }
        }

        [Fact]
        public void Can_Enumerate_After_Adding()
        {
            var bag = new Bag<int>();
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);

            bool found1, found2, found3;
            found1 = found2 = found3 = false;

            foreach (var item in bag)
            {
                if (item == 1) { found1 = true; }
                if (item == 2) { found2 = true; }
                if (item == 3) { found3 = true; }
            }

            Assert.True(found1 && found2 && found3);
        }

        [Fact]
        public void Can_Enumerate_After_Clear()
        {
            var bag = new Bag<int>();
            bag.Add(113);

            bag.Clear();
            var count = 3;
            for (var i = 0; i < count; i++)
            {
                bag.Add(i);
            }

            var check = 0;
            foreach (var item in bag)
            {
                if (item == 0 || item == 1 || item == 2)
                {
                    check += item;
                }
            }

            Assert.Equal(3, check);
        }

        [Fact]
        public void Can_Clear()
        {
            new Bag<int>().Clear();
        }

        [Fact]
        public void Clear_Clears_Curent_Values()
        {
            var bag = new Bag<int>();
            bag.Add(11);
            bag.Add(12);
            bag.Add(13);

            bag.Clear();

            Assert.Empty(bag);
            Assert.Equal(0, bag.Count);
            Assert.True(bag.IsEmpty);
        }

        [Fact]
        public void Count_Returns_Zero_While_Empty()
        {
            Assert.Equal(0, new Bag<int>().Count);
        }

        [Fact]
        public void Count_Returns_Number_Of_Values()
        {
            var bag = new Bag<int>();
            var count = 10;
            for (var i = 0; i < count; i++)
            {
                bag.Add(i);
            }

            Assert.Equal(count, bag.Count);
        }

        [Fact]
        public void IsEmpty_Returns_True_While_Empty()
        {
            Assert.True(new Bag<int>().IsEmpty);
        }
    }
}