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
        
        var queue = priorityQueue.GetQueue();

        for (var i = 0; i < expectedResult.Length; i++)
        {
            
            Assert.AreEqual(expectedResult[i].Value, queue[i].Value);
        }
    }

    [TestMethod]
    // Scenario: 5 items are added in the order of Medium, Low1, High1, Low2, High2. 
    // The Dequeue function shall remove the item with the highest priority and return its value.
    // If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
    // Expected Result: High1, High2, Medium, Low1, Low2
    // Defect(s) Found: Order is not correct, expected High2, acutal High1
    public void TestPriorityQueue_2()
    {
        var high1 = new PriorityItem("High1", 3);
        var high2 = new PriorityItem("High2", 3);
        var medium = new PriorityItem("Medium", 2);
        var low1 = new PriorityItem("Low1", 1);
        var low2 = new PriorityItem("Low2", 1);

        PriorityItem[] expectedResult = [high1, high2, medium, low1, low2];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(medium.Value, medium.Priority);
        priorityQueue.Enqueue(low1.Value, low1.Priority);
        priorityQueue.Enqueue(high1.Value, high1.Priority);
        priorityQueue.Enqueue(low2.Value, low2.Priority);
        priorityQueue.Enqueue(high2.Value, high2.Priority);
        
        for (var i = 0; i < expectedResult.Length; i++)
        {
            Assert.AreEqual(priorityQueue.Dequeue(), expectedResult[i].Value);
        }
    }

    [TestMethod]
    // Scenario: If the queue is empty, then an error exception shall be thrown.
    // Expected Result: The queue is empty
    // Defect(s) found: nope
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        try {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        } 
        catch (InvalidOperationException e) {
            Assert.AreEqual("The queue is empty.", e.Message);
        } 
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
        
    }
}