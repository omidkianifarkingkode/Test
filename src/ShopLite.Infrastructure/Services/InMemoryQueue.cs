using ShopLite.Application.Services;

namespace ShopLite.Infrastructure.Services;

public class InMemoryQueue<T> : IQueue<T>
{
    // TODO: Implement this as a simple FIFO queue using your own logic.
    // Do NOT use built-in Queue<T> or other ready-made queue structures.
    // After implementing it, register it in DI: IQueue<> → InMemoryQueue<>.

    public void Enqueue(T item)
    {
        // TODO: add item to internal storage structure
        throw new NotImplementedException();
    }

    public T Dequeue()
    {
        // TODO: remove and return the oldest inserted item (FIFO)
        throw new NotImplementedException();
    }

    public T Peek()
    {
        // TODO: return the oldest item without removing it
        throw new NotImplementedException();
    }

    public int Count
    {
        get
        {
            // TODO: return number of stored items
            throw new NotImplementedException();
        }
    }

    public bool IsEmpty
    {
        get
        {
            // TODO: return true when no items remain
            throw new NotImplementedException();
        }
    }
}
