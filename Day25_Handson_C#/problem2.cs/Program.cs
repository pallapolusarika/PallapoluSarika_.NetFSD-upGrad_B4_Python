/*Problem: 2 - OCP – Open Closed Principle
Scenario: Discount Calculation System
An e-commerce system calculates discounts for different customer types:
•	Regular Customer
•	Premium Customer
•	VIP Customer
The system should allow adding new discount types without modifying existing code.

Requirements:
1.Create an abstract class or interface:
IDiscountStrategy
2.	Implement discount classes:
•	RegularCustomerDiscount
•	PremiumCustomerDiscount
•	VipCustomerDiscount
3.	Each class should implement a method:
CalculateDiscount(double amount)
Technical Constraints:
•	Use interface or abstract class
•	Existing classes should not be modified when adding new discounts
•	Follow Open for Extension, Closed for Modification
Expectations:
	Students should implement:
•	IDiscountStrategy
•	3 Discount Classes
•	A class that calculates the final price*/

using System;
interface IDiscountStrategy
{
    double CalculateDiscount(double amount);
}
class RegularCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.06; 
    }
}
class PremiumCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.11; 
    }
}
class VipCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount)
    {
        return amount * 0.20; // 20% discount
    }
}
class PriceCalculator
{
    public double GetFinalPrice(double amount, IDiscountStrategy discountStrategy)
    {
        double discount = discountStrategy.CalculateDiscount(amount);
        return amount - discount;
    }
}
class Program
{
    static void Main()
    {
        PriceCalculator calculator = new PriceCalculator();

        double amount = 1000;
        double regularPrice = calculator.GetFinalPrice(amount, new RegularCustomerDiscount());
        Console.WriteLine("Regular Final Price: " + regularPrice);

        double premiumPrice = calculator.GetFinalPrice(amount, new PremiumCustomerDiscount());
        Console.WriteLine("Premium Final Price: " + premiumPrice);

     
        double vipPrice = calculator.GetFinalPrice(amount, new VipCustomerDiscount());
        Console.WriteLine("VIP Final Price: " + vipPrice);
    }
}
