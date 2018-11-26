namespace Library
{
    public interface ICountableCollection
    {
        bool IsEmpty { get; }
        int Count { get; }
    }
}