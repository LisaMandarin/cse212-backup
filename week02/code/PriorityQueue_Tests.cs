using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 3 items are added in the order of High, Low, Medium.
    // The Enqueue function shall add an item (which contains both data and priority) to the back of the queue.
    // Expected Result: High, Low, Medium
    // Defect(s) Found: expected High, actual Low
    public void TestPriorityQueue_1()
    {
        var high = new PriorityItem("High", 3);
        var low = new PriorityItem("Low", 1);
        var medium = new PriorityItem("Medium", 2);

        PriorityItem[] expectedResult = [high, low, medium];
        
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(high.Value, high.Priority);
        priorityQueue.Enqueue(low.Value, low.Priority);
        priorityQueue.Enqueue(medium.Value, medium.Priority);
        
        for (var i = 0; i < expectedResult.Length; i++)
        {
            Assert.AreEqual(expectedResult[i].Value, priorityQueue.Dequeue());
        }
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}