/*Level - 2 Problem 5: Vehicle Rental System
Scenario:
A vehicle rental company wants a system where different vehicle types calculate rental charges differently.
Requirements:
1.Create a base class Vehicle with properties Brand and RentalRatePerDay.
2. Create derived classes Car and Bike.
3. Override CalculateRental(int days) method.
4. Car adds insurance charge of 500 per rental.
5. Bike offers 5% discount on total rental.
Technical Constraints:
• Use encapsulation with proper access modifiers.
• Apply runtime polymorphism.
• Validate number of rental days.
Expectations:
• Use base class reference to call overridden methods.
• Implement clean class hierarchy.
• Display final rental cost.
Learning Outcome:
• Master inheritance and polymorphism.
• Implement real-world OOP scenarios.
• Improve object-oriented design skills.
Sample Input: 
Car RentalRatePerDay = 2000, Days = 3
Sample Output: 
Total Rental = 6500*/

using System;

class Vehicle
{
    private string brand;
    private double rentalRatePerDay;

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public double RentalRatePerDay
    {
        get { return rentalRatePerDay; }
        set
        {
            if (value >= 0)
                rentalRatePerDay = value;
            else
                Console.WriteLine("Rental rate cannot be negative.");
        }
    }

    public virtual double CalculateRental(int days)
    {
        return RentalRatePerDay * days;
    }
}

class Car : Vehicle
{
    public override double CalculateRental(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Invalid number of rental days.");
            return 0;
        }

        double total = (RentalRatePerDay * days) + 500; // insurance charge
        return total;
    }
}

class Bike : Vehicle
{
    public override double CalculateRental(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Invalid number of rental days.");
            return 0;
        }

        double total = RentalRatePerDay * days;
        total = total - (total * 0.05); // 5% discount
        return total;
    }
}

class Program
{
    static void Main()
    {
        Vehicle vehicle;

        vehicle = new Car();
        vehicle.Brand = "Toyota";
        vehicle.RentalRatePerDay = 3000;

        Console.WriteLine("Car Total Rental = " + vehicle.CalculateRental(3));

        vehicle = new Bike();
        vehicle.Brand = "Honda";
        vehicle.RentalRatePerDay = 500;

        Console.WriteLine("Bike Total Rental = " + vehicle.CalculateRental(3));
    }
}
