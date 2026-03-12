/*Level - 1 Problem 2: Stack - Based Undo System
Scenario:
Design a simple text editor undo feature using Stack (LIFO principle).
Requirements:
-Implement stack using arrays.
-Support push(add action) and pop(undo action).
-Display current state after each operation.
Technical Constraints:
-Only array - based stack implementation.
-Must follow LIFO order strictly.
- Handle empty stack condition.
Sample Input:
Actions: Type A, Type B, Type C, Undo, Undo
Sample Output:
Current State After Operations: Type A
Expectations:
-Correct LIFO implementation.
-Proper error handling.
-Clear logic structure.


Learning Outcome:
-Understand stack operations.
-Learn LIFO principle application.
- Implement stack using arrays.*/

using System;

class StackUndo
{
    string[] stack = new string[10];
    int top = -1;

    public void Push(string action)
    {
        if (top == stack.Length - 1)
        {
            Console.WriteLine("Stack Overflow");
            return;
        }

        top++;
        stack[top] = action;
        Console.WriteLine("Current State: " + stack[top]);
    }

    public void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack Empty");
            return;
        }

        Console.WriteLine("Undo: " + stack[top]);
        top--;
        if (top >= 0)
            Console.WriteLine("Current State: " + stack[top]);
    }

    public string FinalState()
    {
        return stack[top];
    }
}

class Program
{
    static void Main()
    {
        StackUndo editor = new StackUndo();

        editor.Push("Type A");
        editor.Push("Type B");
        editor.Push("Type C");

        editor.Pop();
        editor.Pop();

        Console.WriteLine("Current State After Operations: " + editor.FinalState());
    }
}