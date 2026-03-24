/*Problem 3- LSP – Liskov Substitution Principle
Scenario: Shape Area Calculator
A graphics application calculates the area of different shapes.
Any derived class should be able to replace the base class without breaking functionality.
Requirements:
1.Create a base class or interface:
•	Shape
2.	Derived classes:
•	Rectangle
•	Circle
3.	Each shape should implement:
•	CalculateArea()
4.A method should accept Shape object and calculate area.
Technical Constraints:
•	Use method overriding
•	Derived classes must not break base class behavior
Expectations:
Students should demonstrate that the program works correctly when:
•	Rectangle object is used
•	Circle object is used*/


using System;
abstract class Shape
{
    public abstract double CalculateArea();
}
class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }
    public override double CalculateArea()
    {
        return Length * Width;
    }
}
class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}
class AreaCalculator
{
    public static void PrintArea(Shape shape)
    {
        Console.WriteLine("Area: " + shape.CalculateArea());
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("1. Rectangle");
        Console.WriteLine("2. Circle");
        Console.Write("Choose Shape: ");
        int choice = int.Parse(Console.ReadLine());
        Shape shape = null;
        if (choice == 1)
        {
            Rectangle rect = new Rectangle();

            Console.Write("Enter Length: ");
            rect.Length = double.Parse(Console.ReadLine());

            Console.Write("Enter Width: ");
            rect.Width = double.Parse(Console.ReadLine());

            shape = rect;
        }
        else if (choice == 2)
        {
            Circle cir = new Circle();
            Console.Write("Enter Radius: ");
            cir.Radius = double.Parse(Console.ReadLine());
            shape = cir;
        }

        AreaCalculator.PrintArea(shape);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
