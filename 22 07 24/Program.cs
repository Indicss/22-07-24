using System;
using System.Collections.Generic;

public class PriorityQueue<T>
{
    private List<PriorityQueueItem<T>> queue;

    public PriorityQueue()
    {
        queue = new List<PriorityQueueItem<T>>();
    }

    public void Enqueue(T item, int priority)
    {
        var newItem = new PriorityQueueItem<T>(item, priority);
        int i = 0;
        while (i < queue.Count && queue[i].Priority >= priority)
        {
            i++;
        }
        queue.Insert(i, newItem);
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Coada de prioritate este goala.");
        }

        var item = queue[0].Item;
        queue.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Coada de prioritate este goala.");
        }

        return queue[0].Item;
    }

    public bool IsEmpty()
    {
        return queue.Count == 0;
    }

    private class PriorityQueueItem<U>
    {
        public U Item { get; }
        public int Priority { get; }

        public PriorityQueueItem(U item, int priority)
        {
            Item = item;
            Priority = priority;
        }
    }
}

public class Program
{
    public static void Main()
    {
        var intQueue = new PriorityQueue<int>();
        intQueue.Enqueue(5, 2);
        intQueue.Enqueue(1, 1);
        intQueue.Enqueue(10, 3);
        Console.WriteLine("Coada de Prioritate pentru int:");
        while (!intQueue.IsEmpty())
        {
            Console.WriteLine(intQueue.Dequeue());
        }
        var stringQueue = new PriorityQueue<string>();
        stringQueue.Enqueue("Scazuta", 1);
        stringQueue.Enqueue("Inalta", 3);
        stringQueue.Enqueue("Mediu", 2);
        Console.WriteLine("\nCoada de Prioritate pentru string:");
        while (!stringQueue.IsEmpty())
        {
            Console.WriteLine(stringQueue.Dequeue());
        }
    }
}
