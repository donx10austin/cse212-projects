using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.
    /// The node is always added to the back of the queue regardless of the priority.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // 1. Find the index of the item with the highest priority.
        var highPriorityIndex = 0;
        
        // Loop through the entire list to ensure no items are skipped.
        for (int index = 1; index < _queue.Count; index++)
        {
            // Use '>' to maintain FIFO for equal priorities. 
            // This ensures the first item found at that priority level stays the winner.
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // 2. Extract the item and its metadata
        var item = _queue[highPriorityIndex];
        
        // 3. Remove the item from its current position
        _queue.RemoveAt(highPriorityIndex);

        // 4. Handle Turn Logic (Re-enqueuing)
        // Infinite turns: 0 or negative
        if (item.Turns <= 0)
        {
            _queue.Add(item);
        }
        // Multiple turns: Decrement and add back to the end
        else if (item.Turns > 1)
        {
            item.Turns -= 1;
            _queue.Add(item);
        }
        // Exactly 1 turn: Do nothing (item stays removed)

        return item.Value;
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
    internal int Turns { get; set; } // Added to support turn-based logic

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
        // Defaulting Turns based on logic or a provided value 
        // (Note: ensure your Enqueue method passes this if needed)
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}