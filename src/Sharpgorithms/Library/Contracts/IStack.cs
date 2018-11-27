namespace Library
{
    public interface IStack<T> : ICountableCollection
    {
        void Push(T value);

        T Pop();

        T Peek();
    }
}