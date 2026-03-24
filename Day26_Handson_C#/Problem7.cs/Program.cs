/*Problem 7- Implementing Repository Pattern
Scenario: Student Data Management System
A training institute needs a system to manage student information.
Instead of directly writing database access code in the main program, the development team decides to use the Repository Pattern.
The repository will act as a data access layer between the application and the data source.
For simplicity, student data will be stored in a List collection.
 
Requirements:
Create the following components:
Entity Class:
Student
Properties:
StudentId
StudentName
Course
Repository Interface:
IStudentRepository
Methods:
AddStudent(Student student)
GetAllStudents()
GetStudentById(int id)
DeleteStudent(int id)

Repository Implementation:
	StudentRepository
Store data using:
List<Student>

Main Program
Demonstrate:
•	Adding students
•	Viewing students
•	Finding student by ID
•	Deleting student

Expectations:
Students should implement separation between:
Business Logic
        ↓
Repository Layer
        ↓
Data Storage


Learning Outcome:
Students will understand:
•	Separation of concerns
•	Data access abstraction
•	Clean architecture basics
•	How repositories simplify data operations*/

using System;
class Program
{
    static void Main(string[] args)
    {
        IStudentRepository repo = new StudentRepository();
        while (true)
        {
            Console.WriteLine("\n1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Find Student by ID");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Student s = new Student();

                    Console.Write("Enter ID: ");
                    s.StudentId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    s.StudentName = Console.ReadLine();

                    Console.Write("Enter Course: ");
                    s.Course = Console.ReadLine();

                    repo.AddStudent(s);
                    Console.WriteLine("Student Added!");
                    break;

                case 2:
                    var all = repo.GetAllStudents();
                    foreach (var st in all)
                    {
                        Console.WriteLine($"{st.StudentId} - {st.StudentName} - {st.Course}");
                    }
                    break;

                case 3:
                    Console.Write("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());

                    var student = repo.GetStudentById(id);
                    if (student != null)
                        Console.WriteLine($"{student.StudentId} - {student.StudentName} - {student.Course}");
                    else
                        Console.WriteLine("Student not found");
                    break;

                case 4:
                    Console.Write("Enter ID: ");
                    int delId = int.Parse(Console.ReadLine());

                    repo.DeleteStudent(delId);
                    Console.WriteLine("Deleted!");
                    break;

                case 5:
                    return;
            }
        }
    }
}