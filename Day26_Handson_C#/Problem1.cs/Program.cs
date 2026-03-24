/*Problem: 1 - SRP – Single Responsibility Principle
Scenario: Student Report Generator
A training institute like Codempower Academy maintains student information and generates performance reports. Currently, one class performs student data storage and report generation, which makes the code difficult to maintain.
Requirements:
1.Create a Student class with properties:
•	StudentId
•	StudentName
•	Marks
2.Create a class responsible for managing student data.
3.Create a separate class responsible for generating reports.
 4.The report should display:

Security Requirements(Secure Coding Practices)
Students must implement the following security measures:
Technical Constraints:
•	Use C# (.NET Console Application).
•	Each class must have only one responsibility.
•	Do not mix data storage and report generation logic in the same class.
Expectations:
Students should implement at least three classes:
•	Student
•	StudentRepository
•	ReportGenerator*/

using System;
using System.Collections.Generic;


class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int Marks { get; set; }
}


class StudentRepository
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student s)
    {
        students.Add(s);
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }
}


class ReportGenerator
{
    public void GenerateReport(List<Student> students)
    {
        Console.WriteLine("\n------ Student Report ------");

        foreach (var s in students)
        {
            string result = s.Marks >= 35 ? "Pass" : "Fail";

            Console.WriteLine($"Student ID: {s.StudentId}");
            Console.WriteLine($"Student Name: {s.StudentName}");
            Console.WriteLine($"Student Marks: {s.Marks}");
            Console.WriteLine($"Result: {result}");
            Console.WriteLine("----------------------------");
        }
    }
}


class Program
{
    static void Main()
    {
        StudentRepository repo = new StudentRepository();
        ReportGenerator report = new ReportGenerator();

        Console.Write("Enter number of students: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"\nEnter details for Student {i}:");

            Student s = new Student();

            Console.Write("Enter Student ID: ");
            s.StudentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Name: ");
            s.StudentName = Console.ReadLine();

            Console.Write("Enter Marks: ");
            s.Marks = int.Parse(Console.ReadLine());

            repo.AddStudent(s);
        }

        
        var students = repo.GetAllStudents();
        report.GenerateReport(students);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}