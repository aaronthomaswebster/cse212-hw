public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Create a priority queue with the following values and priorities: value 1 (1)
        // run until the queue is empty. This test is to verify that the queue can handle a single item.
        // Expected Result: 
        //  value 1
        //  The queue is empty.
        //
        Console.WriteLine("Test 1");
        priorityQueue.Enqueue("value 1", 1);

        String value = priorityQueue.Dequeue();
        while (value != null){
            Console.WriteLine(value);
            value = priorityQueue.Dequeue();
        }


        // Defect(s) Found: None

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Create a priority queue with the following values and priorities: value 1 (1), value 2 (10), value 3 (5)
        // run until the queue is empty
        // Expected Result: value 2, value 1, value 3
         // Expected Result: 
        //  value 2
        //  value 1
        //  value 3
        //  The queue is empty.
        priorityQueue = new PriorityQueue();
        Console.WriteLine("Test 2");
        priorityQueue.Enqueue("value 1", 5);
        priorityQueue.Enqueue("value 2", 10);
        priorityQueue.Enqueue("value 3", 1);

        value = priorityQueue.Dequeue();
        while (value != null){
            Console.WriteLine(value);
            value = priorityQueue.Dequeue();
        }
        // Defect(s) Found: the Dequeue function was not removing the highest priority item from the list, it was just returning its value.

        Console.WriteLine("---------");

        // Test 3
        // Scenario:  Create a priority queue with the following values and priorities: value 1 (1), value 2 (10), value 3 (10), , value 4 (5)
        // run until the queue is empty
        // Expected Result:  
        //  value 2
        //  value 3
        //  value 4
        //  value 1
        Console.WriteLine("Test 3");
        priorityQueue.Enqueue("value 1", 1);
        priorityQueue.Enqueue("value 2", 10);
        priorityQueue.Enqueue("value 3", 10);
        priorityQueue.Enqueue("value 4", 5);

        value = priorityQueue.Dequeue();
        while (value != null){
            Console.WriteLine(value);
            value = priorityQueue.Dequeue();
        }
        // Defect(s) Found: the for loop in the Dequeue function was not checking the last item in the queue. I should have caught this earlier.


        Console.WriteLine("---------");

        // Test 4
        // Scenario:  Initailize an empty priority queue and run until the queue is empty
        // run until the queue is empty
        // Expected Result:  
        //  The queue is empty.
        Console.WriteLine("Test 4");

        value = priorityQueue.Dequeue();
        while (value != null){
            Console.WriteLine(value);
            value = priorityQueue.Dequeue();
        }
        // Defect(s) Found: None

        Console.WriteLine("---------");
    }
}