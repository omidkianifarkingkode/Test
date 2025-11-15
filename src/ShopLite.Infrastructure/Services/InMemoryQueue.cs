using System;
using System.Collections.Generic;

using ShopLite.Application.Services;

namespace ShopLite.Infrastructure.Services;

public class InMemoryQueue<T> : IQueue<T>
{
    private readonly List<T> _items = new();

    public void Enqueue(T item)
    {
        _items.Add(item);
    }

    public T Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var item = _items[0];
        _items.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return _items[0];
    }

    public int Count => _items.Count;

    public bool IsEmpty => _items.Count == 0;
}
