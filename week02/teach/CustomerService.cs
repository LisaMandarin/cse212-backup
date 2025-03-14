/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: The maximum size of the Customer Service Queue is set to 0 when it is created.
        // Expected Result: The size is 10 by default
        Console.WriteLine("Test 1");
        // Defect(s) Found: Nope

        // var service = new CustomerService(0);
        // Console.WriteLine(service.ToString());
        
        Console.WriteLine("=================");

        // Test 2
        // Scenario: The maximum size of the Customer Service Queue is set to 5 when it is created.  Add two customers in the order of customer A and customer B
        // Expected Result: [customer A, customer B], maximum size = 5
        Console.WriteLine("Test 2");
        // Defect(s) Found: nope

        // var service = new CustomerService(5);
        // service.AddNewCustomer();
        // service.AddNewCustomer();
        // Console.WriteLine(service.ToString());

        Console.WriteLine("=================");

        // Test 3
        // Scenario: The maximum size of the queue is set to 2 when it is created.  Add three customers.
        // Expected Result: An error message is displayed to show the queue is full after two customer are added to the queue.
        Console.WriteLine("Test 3");
        // Defect(s) Found: No error showing when reaching the maximum size of the queue
        
        // var service = new CustomerService(2);
        // service.AddNewCustomer();
        // service.AddNewCustomer();
        // service.AddNewCustomer();

        Console.WriteLine("=================");

        // Test 4
        // Scenario: The maximum size is 3, add 3 customers in the order of A, B, C.  Serve the three customers.
        // Expected Result: customers being served in the order of A, B, C
        Console.WriteLine("Test 4");
        // Defect(s) Found: Error on ServeCustomer--Index was out of range. Must be non-negative and less than the size of the collection.
        
        // var service = new CustomerService(3);
        // service.AddNewCustomer();
        // service.AddNewCustomer();
        // service.AddNewCustomer();
        // service.ServeCustomer();
        // service.ServeCustomer();
        // service.ServeCustomer();
        
        Console.WriteLine("=================");

        // Test 4
        // Scenario: The maximum size is 0, add 1 customer.
        // Expected Result: An error message is displayed to show no customer in the queue
        Console.WriteLine("Test 5");
        // Defect(s) Found: Erorr on ServeCustomer--System.ArgumentOutOfRangeException
        var service = new CustomerService(0);
        service.ServeCustomer();
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("No customer in the queue");
            return;
        }
        var customer = _queue[0];
        Console.WriteLine(customer);
        _queue.RemoveAt(0);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}