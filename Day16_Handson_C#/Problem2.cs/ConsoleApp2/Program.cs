// See https://aka.ms/new-console-template for more information
Level - 1 Problem 2: Simple Calculator Using Switch
Scenario
Create a simple calculator application that performs basic arithmetic operations.
Requirements
• Accept two numbers from user.
• Accept operator (+, -, *, /).
• Use switch statement to perform operation.
• Display result.
Technical Constraints
• Use int or double data types.
• Use switch-case statement.
• Handle division by zero.
Sample Input
Enter First Number: 10
Enter Second Number: 5
Enter Operator: *
Sample Output
Result: 50
Expectations
Correct operator selection and proper validation of inputs.
Learning Outcome
Understand switch statements, arithmetic operators and control flow in C#.


using System;

class SimpleCalculator
{
    static void Main()
    {
        double num1, num2;
        char op;

        Console.Write("Enter First Number: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Second Number: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Operator (+, -, *, /): ");
        op = Convert.ToChar(Console.ReadLine());

        switch (op)
        {
            case '+':
                Console.WriteLine("Result: " + (num1 + num2));
                break;

            case '-':
                Console.WriteLine("Result: " + (num1 - num2));
                break;

            case '*':
                Console.WriteLine("Result: " + (num1 * num2));
                break;

            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                }
                else
                {
                    Console.WriteLine("Result: " + (num1 / num2));
                }
                break;

            default:
                Console.WriteLine("Invalid Operator.");
                break;
        }
    }
}
