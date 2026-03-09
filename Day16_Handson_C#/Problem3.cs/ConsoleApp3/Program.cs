// See https://aka.ms/new-console-template for more information
Level - 2 Problem 1: Employee Bonus Calculator
Scenario
Develop a console application that calculates employee bonus based on salary and years of experience.
Requirements
• Accept employee name, salary and years of experience.
• Use if-else and conditional operator.
• Bonus rules:
   -Experience < 2 years: 5 % bonus
   - 2 - 5 years: 10 % bonus
   - > 5 years: 15 % bonus
• Display final salary after bonus.
Technical Constraints
• Use double for salary.
• Use if-else and ternary operator.
• Use proper formatting for currency output.
Sample Input
Enter Name: Aisha
Enter Salary: 50000
Enter Experience: 4
Sample Output
Employee: Aisha
Bonus: 5000
Final Salary: 55000
Expectations
Accurate bonus calculation and correct usage of control statements.
Learning Outcome
Apply conditional logic and arithmetic operations in real-world scenarios.


using System;

class EmployeeBonus
{
    static void Main()
    {
        string name;
        double salary, bonus, finalSalary;
        int experience;

        Console.Write("Enter Name: ");
        name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Experience (years): ");
        experience = Convert.ToInt32(Console.ReadLine());

        // Bonus calculation using if-else
        if (experience < 2)
        {
            bonus = salary * 0.05;
        }
        else if (experience >= 2 && experience <= 5)
        {
            bonus = salary * 0.10;
        }
        else
        {
            bonus = salary * 0.15;
        }

        // Final salary using ternary operator
        finalSalary = (bonus > 0) ? salary + bonus : salary;

        Console.WriteLine("\nEmployee: " + name);
        Console.WriteLine("Bonus: " + bonus.ToString("F2"));
        Console.WriteLine("Final Salary: " + finalSalary.ToString("F2"));
    }
}
