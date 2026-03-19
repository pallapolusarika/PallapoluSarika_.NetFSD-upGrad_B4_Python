/*Level - 1 Problem 1:
Scenario
A financial application needs to process multiple reports simultaneously to reduce waiting time. Instead of executing tasks sequentially, the system should run them concurrently using C# Tasks so that reports are generated faster.
Requirements
1.Create three methods:
a.GenerateSalesReport()
b.GenerateInventoryReport()
c.GenerateCustomerReport()
2.Each method should simulate processing time using Thread.Sleep() or Task.Delay().
3.Execute all three operations concurrently using Task.
4.Display a message when each report starts and when it finishes.
5.	Display a final message once all reports are completed.
Technical Constraints
•	Use Task class from System.Threading.Tasks.
•	Use Task.Run() to execute methods.
•	Use Task.WaitAll() or await Task.WhenAll() to wait for completion.
•	The program must run in a Console Application.
Expectations
The program should start multiple report-generation tasks simultaneously and display completion messages for each report along with a final message once all tasks are completed.
Learning Outcome
Students will learn:
•	How to create and run Tasks in C#
•	How to execute multiple operations concurrently
•	How to wait for multiple tasks to complete*/




using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Start tasks concurrently
        Task t1 = Task.Run(() => GenerateSalesReport());
        Task t2 = Task.Run(() => GenerateInventoryReport());
        Task t3 = Task.Run(() => GenerateCustomerReport());

        // Wait for all tasks to complete
        Task.WaitAll(t1, t2, t3);

        Console.WriteLine("\nAll reports generated successfully!");
    }

    static void GenerateSalesReport()
    {
        Console.WriteLine("Sales Report started...");
        Thread.Sleep(3000); // simulate work
        Console.WriteLine("Sales Report completed.");
    }

    static void GenerateInventoryReport()
    {
        Console.WriteLine("Inventory Report started...");
        Thread.Sleep(2000);
        Console.WriteLine("Inventory Report completed.");
    }

    static void GenerateCustomerReport()
    {
        Console.WriteLine("Customer Report started...");
        Thread.Sleep(2500);
        Console.WriteLine("Customer Report completed.");
    }
}
