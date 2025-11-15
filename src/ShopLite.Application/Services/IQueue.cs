namespace ShopLite.Application.Services;

public interface IQueue<T>
{
    void Enqueue(T item);
    T Dequeue();
    T Peek();
    int Count { get; }
    bool IsEmpty { get; }
}
