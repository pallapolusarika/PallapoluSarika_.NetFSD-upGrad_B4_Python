/*Level - 2 Problem 3: Application Tracing for Order Processing
Scenario
An e-commerce application processes customer orders. Sometimes the order processing fails, but developers are unable to identify where the failure occurs. The team decides to implement Tracing to monitor the execution flow and diagnose the issue.
Requirements
•	Create a console application that simulates order processing.
•	The order processing should include the following steps:
1.Validate Order
2.	Process Payment
3.	Update Inventory
4.	Generate Invoice
•	Use Trace class to log messages at each step of the process.
•	Display trace messages showing the execution flow.
Technical Constraints
•	Use System.Diagnostics.Trace.
•	Write trace messages using:
o Trace.WriteLine()
o Trace.TraceInformation()
•	Configure a TextWriterTraceListener to store trace logs in a file.
•	Implement the solution using .NET console application.
Expectations
•	The application should log messages for each stage of order processing.
•	Trace logs should help developers identify where failures occur.
•	The trace output should be stored in a log file.
Learning Outcome
Students will learn how to:
•	Implement application tracing using System.Diagnostics.
•	Monitor application flow using Trace listeners.
•	Use trace logs to diagnose runtime issues in real-world applications.*/

using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        
        Trace.Listeners.Add(new TextWriterTraceListener("traceLog.txt"));
        Trace.AutoFlush = true;

        Console.WriteLine("Order Processing Started...\n");

        try
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Console.WriteLine("\nOrder processed successfully!");
        }
        catch (Exception ex)
        {
            Trace.WriteLine("Error: " + ex.Message);
            Console.WriteLine("Order processing failed!");
        }

        Console.ReadLine();
    }

    static void ValidateOrder()
    {
        Trace.TraceInformation("Step 1: Validating Order...");
        Console.WriteLine("Validating Order...");
    }

    static void ProcessPayment()
    {
        Trace.TraceInformation("Step 2: Processing Payment...");
        Console.WriteLine("Processing Payment...");
    }

    static void UpdateInventory()
    {
        Trace.TraceInformation("Step 3: Updating Inventory...");
        Console.WriteLine("Updating Inventory...");
    }

    static void GenerateInvoice()
    {
        Trace.TraceInformation("Step 4: Generating Invoice...");
        Console.WriteLine("Generating Invoice...");
    }
}
