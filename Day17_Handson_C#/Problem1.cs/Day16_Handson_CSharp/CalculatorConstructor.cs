using System;

class CalculatorConstructor
{
    private int num1;
    private int num2;

    public CalculatorConstructor(int a, int b)
    {
        num1 = a;
        num2 = b;
    }

    public int Add()
    {
        return num1 + num2;
    }

    public int Subtract()
    {
        return num1 - num2;
    }

    public void Run()
    {
        Console.WriteLine("Constructor Problem");
        Console.WriteLine("Addition = " + Add());
        Console.WriteLine("Subtraction = " + Subtract());
    }
}