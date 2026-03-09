// See https://aka.ms/new-console-template for more information
// Level - 2 Problem 2: Number Analysis Using Loops
Scenario
Create a .NET 8 console application that analyzes numbers between 1 and N.
Requirements
• Accept a number N from user.
• Use loops to:
   -Count even numbers
   -Count odd numbers
   - Calculate sum of all numbers
• Display results.
Technical Constraints
• Use for or while loop.
• Use int data type.
• Avoid using arrays or collections.
Sample Input
Enter Number: 10
Sample Output
Even Count: 5
Odd Count: 5
Sum: 55
Expectations
Proper loop usage and correct counting logic.
Learning Outcome
Strengthen understanding of loops, counters and accumulators in C#.

using System;

class NumberAnalysis
{
    static void Main()
    {
        int N;
        int evenCount = 0;
        int oddCount = 0;
        int sum = 0;

        Console.Write("Enter Number: ");
        N = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= N; i++)
        {
            sum = sum + i;

            if (i % 2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }
        }

        Console.WriteLine("Even Count: " + evenCount);
        Console.WriteLine("Odd Count: " + oddCount);
        Console.WriteLine("Sum: " + sum);
    }
}
