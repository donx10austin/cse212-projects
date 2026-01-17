using System;
using System.Collections.Generic;

/// <summary>
/// A simple FIFO queue for Person objects
/// </summary>
public class PersonQueue
{
    private List<Person> _queue = new();

    /// <summary>
    /// Add a person to the back of the queue
    /// </summary>
    public void Enqueue(Person person)
    {
        _queue.Add(person);
    }

    /// <summary>
    /// Remove and return the person from the front of the queue
    /// </summary>
    public Person Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        Person person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    /// <summary>
    /// Check if the queue is empty
    /// </summary>
    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    /// <summary>
    /// Get the number of people in the queue
    /// </summary>
    public int Length => _queue.Count;

    /// <summary>
    /// Return a string representation of the queue
    /// </summary>
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
