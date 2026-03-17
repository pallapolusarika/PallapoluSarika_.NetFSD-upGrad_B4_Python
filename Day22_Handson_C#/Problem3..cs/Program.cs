/*Problem 3 – Level 1:
Employee Performance Evaluator using Tuples and Pattern Matching(Level-1)
Scenario
A small company wants a simple program that evaluates an employee's performance based on two inputs: monthly sales amount and customer feedback rating.
The system should return both values together using a Tuple, and then determine the performance category using pattern matching.
This will help management quickly identify whether an employee is a High Performer, Average Performer, or Needs Improvement.




Requirements
1.	Accept the following inputs from the user:
o Employee Name
o	Monthly Sales Amount
o	Customer Feedback Rating (1–5)
2.	Create a method that returns Sales Amount and Rating together using a Tuple.
3.Use pattern matching with switch expression or switch statement to categorize performance:
o High Performer → Sales ≥ 100000 AND Rating ≥ 4
o	Average Performer → Sales ≥ 50000 AND Rating ≥ 3
o	Needs Improvement → All other cases
4.	Display:
o Employee Name
o	Sales Amount
o	Rating
o	Performance Category
Technical Constraints
•	The method must return multiple values using Tuple.
•	Pattern matching must be used for performance classification.
•	Avoid using multiple nested if-else statements.
•	Input values must be numeric and valid.
Expectations
•	Students should demonstrate how to create and return tuples from a method.
•	Students should use pattern matching to simplify conditional logic.
•	Output should be clearly formatted.


Example Output:
Employee Name: Rahul
Sales Amount: 120000
Rating: 4
Performance: High Performer
Learning Outcome
After completing this problem, students will be able to:
•	Understand how tuples return multiple values from methods.
•	Apply pattern matching to simplify complex conditions.
•	Write cleaner and more readable decision logic in C#.*/

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Monthly Sales Amount: ");
        if (!double.TryParse(Console.ReadLine(), out double sales))
        {
            Console.WriteLine("Invalid sales input!");
            return;
        }

        Console.Write("Enter Customer Rating (1-5): ");
        if (!int.TryParse(Console.ReadLine(), out int rating) || rating < 1 || rating > 5)
        {
            Console.WriteLine("Invalid rating input!");
            return;
        }
        var result = GetPerformanceData(sales, rating);
        string performance = result switch
        {
            ( >= 100000, >= 4) => "High Performer",
            ( >= 50000, >= 3) => "Average Performer",
            _ => "Needs Improvement"
        };

        Console.WriteLine("\nEmployee Details:");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Sales Amount: " + result.sales);
        Console.WriteLine("Rating: " + result.rating);
        Console.WriteLine("Performance: " + performance);
    }


    static (double sales, int rating) GetPerformanceData(double sales, int rating)
    {
        return (sales, rating);
    }
}
