/*Level - 2 Problem 4: Online Shopping Cart System
Scenario:
An e-commerce platform needs a flexible cart system where different product types calculate discounts differently.
Requirements:
1.Create a base class Product with properties Name and Price.
2. Create derived classes Electronics and Clothing.
3. Implement a virtual method CalculateDiscount().
4. Electronics get 5% discount, Clothing gets 15% discount.
5. Use encapsulation to protect price updates.
Technical Constraints:
• Use private fields with public properties.
• Apply inheritance and method overriding.
• Prevent negative price assignment.
Expectations:
• Demonstrate polymorphic behavior in cart processing.
• Apply data validation inside properties.
• Calculate and display final price after discount.
Learning Outcome:
• Combine encapsulation and polymorphism.
• Design extensible product hierarchy.
• Implement business logic in overridden methods.
Sample Input: Electronics Price = 20000
Sample Output: Final Price after 5% discount = 19000*/

using System;

class Product
{
    private double price;
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (value >= 0)
                price = value;
            else
                Console.WriteLine("Price cannot be negative");
        }
    }

    public virtual double CalculateDiscount()
    {
        return Price;
    }
}

class Electronics : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.05);
    }
}

class Clothing : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.15);
    }
}

class Program
{
    static void Main()
    {
        Product prod;

        prod = new Electronics();
        prod.Name = "Laptop";
        prod.Price = 20000;
        Console.WriteLine("Electronics Final Price after 5% discount = " + prod.CalculateDiscount());

        prod = new Clothing();
        prod.Name = "T-Shirt";
        prod.Price = 2000;
        Console.WriteLine("Clothing Final Price after 15% discount = " + prod.CalculateDiscount());
    }
}