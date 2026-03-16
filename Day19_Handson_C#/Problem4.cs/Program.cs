/*Level - 2 Problem 2: Student Record Management System Using Record Data Structure

Scenario:
A college wants to develop a console-based Student Record Management System. The system should store and manage student records using a Record data structure. Each student record should contain fields such as Roll Number, Name, Course, and Marks. The system must allow users to add multiple student records, display all records, and search for a student using the Roll Number.
Requirements:
1.Define a Record to store student details.
2. Allow the user to input details for multiple students.
3. Display all student records in a formatted manner.
4. Provide a search functionality to find a student by Roll Number.
5. Display appropriate message if the record is not found.
Technical Constraints:
1.Must use Record data type.
2. Use an array (or list) of records to store multiple students.
3. Do not use external databases.
4. Program should be menu-driven.
5. Input validation must be handled for Roll Number and Marks.

Sample Input:
Enter number of students: 2
Enter Roll Number: 101
Enter Name: Aisha
Enter Course: BCA
Enter Marks: 85

Enter Roll Number: 102
Enter Name: Rahul
Enter Course: BSc
Enter Marks: 78

Search Roll Number: 101

Sample Output:
Student Records:
Roll No: 101 | Name: Aisha | Course: BCA | Marks: 85
Roll No: 102 | Name: Rahul | Course: BSc | Marks: 78

Search Result:
Student Found:
Roll No: 101 | Name: Aisha | Course: BCA | Marks: 85

Expectations:
1.Proper use of Record / Structure syntax.
2. Clean and modular code.
3. Proper formatting of displayed output.
4. Efficient search implementation.
Learning Outcome:
1.Understand how to define and use Record/Structure data types.
2. Learn how to manage multiple records using arrays/ lists.
3.Implement searching techniques on structured data.
4. Develop structured problem-solving skills for real-world scenarios.*/


using System;

struct Student
{
    public int RollNo;
    public string Name;
    public string Course;
    public int Marks;
}

class Program
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Student[] students = new Student[n];
        int count = 0;

        int choice;

        do
        {
            Console.WriteLine("\n1. Add Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (count < n)
                    {
                        Console.Write("Enter Roll Number: ");
                        students[count].RollNo = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        students[count].Name = Console.ReadLine();

                        Console.Write("Enter Course: ");
                        students[count].Course = Console.ReadLine();

                        Console.Write("Enter Marks: ");
                        students[count].Marks = Convert.ToInt32(Console.ReadLine());

                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Student list is full.");
                    }
                    break;

                case 2:
                    Console.WriteLine("\nStudent Records:");
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(
                        "Roll No: " + students[i].RollNo +
                        " | Name: " + students[i].Name +
                        " | Course: " + students[i].Course +
                        " | Marks: " + students[i].Marks);
                    }
                    break;

                case 3:
                    Console.Write("Enter Roll Number to search: ");
                    int searchRoll = Convert.ToInt32(Console.ReadLine());
                    bool found = false;

                    for (int i = 0; i < count; i++)
                    {
                        if (students[i].RollNo == searchRoll)
                        {
                            Console.WriteLine("\nStudent Found:");
                            Console.WriteLine(
                            "Roll No: " + students[i].RollNo +
                            " | Name: " + students[i].Name +
                            " | Course: " + students[i].Course +
                            " | Marks: " + students[i].Marks);

                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Record not found.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 4);
    }
}