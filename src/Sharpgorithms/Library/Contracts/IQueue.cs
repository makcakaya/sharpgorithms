namespace Library
{
    public interface IQueue<T> : ICountableCollection
    {
        void Enqueue(T value);

        T Dequeue();
    }
}