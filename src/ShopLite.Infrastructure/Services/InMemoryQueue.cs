using ShopLite.Application.Services;

namespace ShopLite.Infrastructure.Services;

public class InMemoryQueue<T> : IQueue<T>
{
    // TODO: Implement this as a simple FIFO queue using your own logic.
    // Do NOT use built-in Queue<T> or other ready-made queue structures.
    // After implementing it, register it in DI: IQueue<> → InMemoryQueue<>.
    private readonly List<T> _buffer = new();
    private int _head = 0;

    public void Enqueue(T item)
    {
        // TODO: add item to internal storage structure
        _buffer.Add(item);

    }

    public T Dequeue()
    {
        // TODO: remove and return the oldest inserted item (FIFO)
        if (IsEmpty)
            throw new InvalidOperationException("Queue is empty");
        var item = _buffer[_head++];
        if (_head > 32 && _head * 2 >= _buffer.Count)
        {
            _buffer.RemoveRange(0, _head);
            _head = 0;
        }
        return item;
    }

    public T Peek()
    {
        // TODO: return the oldest item without removing it
        if (IsEmpty)
        throw new InvalidOperationException("Queue is empty");

        return _buffer[_head];
    }

    public int Count => _buffer.Count - _head;

    public bool IsEmpty => Count == 0;

}
