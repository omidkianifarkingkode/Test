using ShopLite.Application.Services;

namespace ShopLite.Infrastructure.Services;

public class InMemoryQueue<T> : IQueue<T>
{
    // TODO: Implement this as a simple FIFO queue using your own logic.
    // Do NOT use built-in Queue<T> or other ready-made queue structures.
    // After implementing it, register it in DI: IQueue<> → InMemoryQueue<>.
    private readonly LinkedList<T> values = new LinkedList<T>();
    public void Enqueue(T item)
    {
        // TODO: add item to internal storage structure
        values.AddLast(item);
        // throw new NotImplementedException();
    }

    public T Dequeue()
    {
        // TODO: remove and return the oldest inserted item (FIFO)
        if (IsEmpty)
            throw new NotImplementedException();
        var value = values.First.Value;
        values.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        // TODO: return the oldest item without removing it
        if (IsEmpty)
            throw new NotImplementedException();

        return values.First.Value;
        // throw new NotImplementedException();
    }

    public int Count
    {
        get
        {
            // TODO: return number of stored items
            return values.Count();
        }
    }

    public bool IsEmpty
    {
        get
        {
            // TODO: return true when no items remain
            return values.Count == 0;
        }
    }
}
