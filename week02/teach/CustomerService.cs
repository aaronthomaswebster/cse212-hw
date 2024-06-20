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
        // Scenario: when customer service queue is created with a size of 0 or less
        // Expected Result: the queue should have a maximum size of 10
        Console.WriteLine("Test 1");

         CustomerService cs = new CustomerService(0);
         Console.WriteLine("The new customer Service Queue has a maximum size of 10: "+(cs._maxSize == 10));

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 2
        // Scenario: When a new customer is added to the queue
        // Expected Result: the queue should have 1 customer
        Console.WriteLine("Test 2");

        CustomerService cs2 = new CustomerService(1);
        cs2.AddNewCustomer();
        Console.WriteLine("The new customer Service Queue has 1 customer: "+(cs2._queue.Count == 1));

        // Defect(s) Found: none 

        Console.WriteLine("=================");

        

        // Test 3
        // Scenario: When a new customer is added to the queue
        // Expected Result: the new customer should not be added to the queue because the queue is full
        cs2.AddNewCustomer();
        Console.WriteLine("The new customer Service Queue has 1 customer: "+(cs2._queue.Count == 1));

        // Defect(s) Found: the "AddNewCustomer" method does not check if the queue is full before adding a new customer,
        // a corection was made that changed the if statement to check for >= instead of >

        
        Console.WriteLine("=================");
        // Test 4
        // Scenario: When a customer is served from the queue
        // Expected Result: the queue count should reduce by 1
        cs2.ServeCustomer();
        Console.WriteLine("The new customer Service Queue has 0 customer: "+(cs2._queue.Count == 0));

        
        // Defect(s) Found: The "ServeCustomer" fuction needed to be refactored to save the customer at position 0 to a variable before removing it from the queue

        Console.WriteLine("=================");
        // Test 5
        // Scenario: When a customer is served from an empty queue
        // Expected Result: an error should be displayed
        cs2.ServeCustomer();
        Console.WriteLine("The new customer Service Queue has 0 customer: "+(cs2._queue.Count == 0));
 
        // Defect(s) Found: The "ServeCustomer" fuction needed to have a check to see if the queue is empty before trying to serve a customer
        // a check was added and a message now displays "No Customers in Queue." if the queue is empty


        // Add more Test Cases As Needed Below
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
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in Queue.");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}