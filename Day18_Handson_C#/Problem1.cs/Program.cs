
/*Level - 1 Problem 1: Student Grade Calculator
Scenario:
A school wants to calculate the average marks of a student using a class-based approach.
Requirements:
1.Create a class Student.
2.Create method CalculateAverage(int m1, int m2, int m3).
3.Return the average marks.
4. Display grade based on average.
Technical Constraints:
1.Use return type double for average.
2. Avoid hard-coded values.
Expectations:
Clear separation of logic inside methods.
Learning Outcome:
Learn method creation, return values, and basic OOP concepts.
Sample Input: 
80 70 90
Sample Output: 
Average = 80, Grade = A*/

using System;

class Student
{
    public double CalculateAverage(int m1, int m2, int m3)
    {
        double avg = (m1 + m2 + m3) / 3;
        return avg;
    }

    public char GetGrade(double average)
    {
        if (average >= 80)
            return 'A';
        else if (average >= 60)
            return 'B';
        else if (average >= 50)
            return 'C';
        else
            return 'F';
    }

    public bool ValidateMarks(int m)
    {
        return m >= 0 && m <= 100;
    }
}

internal class Program
{
    static void Main()
    {
        Console.Write("Enter mark 1: ");
        int m1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter mark 2: ");
        int m2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter mark 3: ");
        int m3 = Convert.ToInt32(Console.ReadLine());

        // Object creation
        Student objStu = new Student();

        if (objStu.ValidateMarks(m1) && objStu.ValidateMarks(m2) && objStu.ValidateMarks(m3))
        {
            double avg = objStu.CalculateAverage(m1, m2, m3);
            char grade = objStu.GetGrade(avg);

            Console.WriteLine("Average = " + avg);
            Console.WriteLine("Grade = " + grade); 
        }
        else
        {
            Console.WriteLine("Invalid Marks! Marks must be between 0 and 100.");
        }
    }
}