using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities
    // Expected: Highest priority item is returned first
    // Defect Found: the queue did not always return the highest priority item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low Priority", 1);
        priorityQueue.Enqueue("Medium Priority", 5);
        priorityQueue.Enqueue("High Priority", 10);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("High Priority", result);
       // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority
    // Expected: Items with the same priority should be returned in the order they were enqueued (FIFO)
    // Defect Found:Initially, FIFO order was not preserved when priorities were equal.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First Item", 5);
        priorityQueue.Enqueue("Second Item", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First Item", result);
     //   Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
    // Scenario: Dequeue multiple items in order of priority
    // Expected: Items are returned from highest to lowest priority
    // Defect Found: Incorrect removal or ordering of items in earlier implementation.
    public void TestPriorityQueue_MultipleDequeues()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue
    // Expected: InvalidOperationException is thrown
    // Defect Found: Missing exception handling in earlier implementation.
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }
}
