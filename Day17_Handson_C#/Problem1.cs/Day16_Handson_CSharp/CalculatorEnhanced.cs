using System;

class CalculatorEnhanced
{
    private int num1;
    private int num2;

    public void SetValues(int a, int b)
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
        SetValues(10, 5);

        Console.WriteLine("Enhanced Problem");
        Console.WriteLine("Addition = " + Add());
        Console.WriteLine("Subtraction = " + Subtract());
    }
}
