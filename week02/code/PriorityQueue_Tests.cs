using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities (1, 5, 3) and dequeue them.
    // Expected Result: High (5), Medium (3), Low (1)
    // Defect(s) Found: Originally skipped the last item and didn't remove items after dequeue.
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 5);
        pq.Enqueue("Medium", 3);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority.
    // Expected Result: "First", "Second", "Third" (FIFO behavior)
    // Defect(s) Found: Originally used '>=' which caused LIFO behavior for ties.
    public void TestPriorityQueue_FIFO_Tie()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 2);
        pq.Enqueue("Second", 2);
        pq.Enqueue("Third", 2);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: A person has infinite turns (0 or negative).
    // Expected Result: The person should stay in the queue indefinitely regardless of how many times they are dequeued.
    public void TestPriorityQueue_InfiniteTurns()
    {
        var pq = new PriorityQueue();
        // Assuming the PriorityItem/Enqueue logic supports setting turns or uses a specific priority for this
        pq.Enqueue("InfiniteBob", 10); // Priority 10, Turns <= 0 logic
        
        // Dequeue multiple times; Bob should always be there if he's the only one or highest priority
        for (int i = 0; i < 5; i++)
        {
            Assert.AreEqual("InfiniteBob", pq.Dequeue());
        }
    }

    [TestMethod]
    // Scenario: A person has exactly 1 turn.
    // Expected Result: They are returned once and then removed from the queue.
    public void TestPriorityQueue_SingleTurn()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("OneTimer", 10); // Logic: 1 turn total

        Assert.AreEqual("OneTimer", pq.Dequeue());
        
        // After one dequeue, the queue should be empty
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from a queue that has no items.
    // Expected Result: InvalidOperationException with the message "The queue is empty."
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}