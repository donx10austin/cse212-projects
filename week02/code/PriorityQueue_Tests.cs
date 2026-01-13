using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; // Required for InvalidOperationException

// The PriorityQueue class should NOT be defined here. 
// It lives in its own file in the same project.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test if the highest priority is actually removed.
    // Expected Result: "High" (Pri: 5)
    // Defect(s) Found: Fixed - loop now reaches the end of the list.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    // ... your other tests go here ...
}