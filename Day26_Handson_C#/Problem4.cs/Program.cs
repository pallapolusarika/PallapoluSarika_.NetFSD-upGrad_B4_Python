/*Problem 4- ISP – Interface Segregation Principle
Scenario: Office Printer System
An office has different machines:
•	Basic Printer(Print only)
•	Advanced Printer(Print + Scan + Fax)
If we create a single large interface, basic printers will be forced to implement unnecessary methods.
The task is to split the interface into smaller interfaces.                  

Requirements:
Create the following interfaces:
•	IPrinter
•	IScanner
•	IFax
Classes:
•	BasicPrinter → Print only
•	AdvancedPrinter → Print + Scan + Fax

Technical Constraints:
•	Follow Interface Segregation Principle
•	Classes should not implement unnecessary methods
Expectations:
Students should implement:
Interfaces
•	IPrinter
•	IScanner
•	IFax
Classes
•	BasicPrinter
•	AdvancedPrinter*/

using System;
interface IPrinter
{
    void Print();
}
interface IScanner
{
    void Scan();
}
interface IFax
{
    void Fax();
}
class BasicPrinter : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Basic Printer: Printing document...");   
    }
}
class AdvancedPrinter : IPrinter, IScanner, IFax
{
    public void Print()
    {
        Console.WriteLine("Advanced Printer: Printing document...");
    }
    public void Scan()
    {
        Console.WriteLine("Advanced Printer: Scanning document...");
    }
    public void Fax()
    {
        Console.WriteLine("Advanced Printer: Sending Fax...");
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("1. Basic Printer");
        Console.WriteLine("2. Advanced Printer");
        Console.Write("Choose option: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            BasicPrinter basic = new BasicPrinter();
            basic.Print();
        }
        else if (choice == 2)
        {
            AdvancedPrinter adv = new AdvancedPrinter();
            adv.Print();
            adv.Scan();
            adv.Fax();
        }
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}