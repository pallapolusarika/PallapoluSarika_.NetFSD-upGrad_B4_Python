using System;

class CalculatorProblem1
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public void Run()
    {
        int add = Add(10, 5);
        int sub = Subtract(10, 5);

        Console.WriteLine("Problem 1");
        Console.WriteLine("Addition = " + add);
        Console.WriteLine("Subtraction = " + sub);
    }
}