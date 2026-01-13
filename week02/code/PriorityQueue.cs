using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public void Enqueue(string value, int priority)
    {
        // Requirement: Add a new value to the back of the queue
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        // Requirement: If the queue is empty, throw InvalidOperationException
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var highPriorityIndex = 0;

        // Fix 1: Use index < _queue.Count to ensure the last item is checked.
        // The original code used Count - 1, which skipped the last element.
        for (int index = 1; index < _queue.Count; index++)
        {
            // Fix 2: Use '>' instead of '>=' to preserve FIFO for equal priorities.
            // This ensures the item closest to the front stays as the highPriorityIndex.
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        var value = _queue[highPriorityIndex].Value;

        // Fix 3: Actually remove the item from the list so the queue shrinks.
        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}