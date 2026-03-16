/*Level - 2 Problem 1: Employee Management Using Linked List
Scenario:
A company wants to maintain employee records dynamically using a Linked List structure.
Requirements:
-Create Node structure with employee ID and name.
- Implement insertion at beginning and end.
- Implement deletion by employee ID.
- Traverse and display employee list.
Technical Constraints:
-Must implement singly linked list.
- No use of built-in list structures.
- Proper memory handling and pointer updates.
Sample Input:
Insert: (101, John), (102, Sara), (103, Mike)
Delete: 102
Sample Output:
Employee List After Deletion:
101 - John
103 – Mike


Expectations:
-Correct node linking.
-Efficient traversal logic.
-Clean insertion and deletion operations.
Learning Outcome:
-Understand linked list structure.
- Perform insertion and deletion operations.
- Learn dynamic data structure behavior.*/

using System;

class Node
{
    public int empId;
    public string name;
    public Node next;

    public Node(int id, string name)     
    {
        this.empId = id;
        this.name = name;
        this.next = null;
    }
}

class EmployeeLinkedList
{
    Node head = null;


    public void InsertBeginning(int id, string name)
    {
        Node newNode = new Node(id, name);
        newNode.next = head;
        head = newNode;
    }

    
    public void InsertEnd(int id, string name)
    {
        Node newNode = new Node(id, name);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;

        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = newNode;
    }

    
    public void Delete(int id)
    {
        if (head == null)
            return;

        if (head.empId == id)
        {
            head = head.next;
            return;
        }

        Node temp = head;

        while (temp.next != null && temp.next.empId != id)
        {
            temp = temp.next;
        }

        if (temp.next != null)
        {
            temp.next = temp.next.next;
        }
    }

   
    public void Display()
    {
        Node temp = head;

        while (temp != null)
        {
            Console.WriteLine(temp.empId + " - " + temp.name);
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        EmployeeLinkedList list = new EmployeeLinkedList();

       
        list.InsertEnd(101, "Sarika");
        list.InsertEnd(102, "Rishitha");
        list.InsertEnd(103, "Chandana");

        
        list.Delete(102);

        Console.WriteLine("Employee List After Deletion:");
        list.Display();
    }
}