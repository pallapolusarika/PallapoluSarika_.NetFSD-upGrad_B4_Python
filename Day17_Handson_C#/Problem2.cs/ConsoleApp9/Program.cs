/*Level - 2 Problem 1: Bank Account with Encapsulation
Scenario:
A bank wants to manage customer accounts securely using encapsulation.
Requirements:
1.Create class BankAccount.
2.Private field: balance.
3.Public methods: Deposit(double amount), Withdraw(double amount).
4.Method GetBalance() to return balance.
5. Prevent withdrawal if insufficient balance.
Technical Constraints:
1.Balance must be private.
2.Access balance only through public methods.
3.Use appropriate return types.
Expectations:
Proper use of encapsulation and object-oriented principles.
Learning Outcome:
Understand encapsulation, access modifiers, and secure data handling.
Sample Input: 
Deposit 1000, Withdraw 300
Sample Output: 
Current Balance = 700*/

using System;

class BankAccount
{
    private double balance = 0;
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance = balance + amount;
            Console.WriteLine("Amount Deposited: " + amount);
        }
        else
        {
            Console.WriteLine("Invalid Deposit Amount");
        }
    }
    public bool Withdraw(double amount)
    {
        if (amount <= balance && amount > 0)
        {
            balance = balance - amount;
            Console.WriteLine("Amount Withdrawn: " + amount);
            return true;
        }
        else
        {
            Console.WriteLine("Insufficient Balance");
            return false;
        }
    }
    public double GetBalance()
    {
        return balance;
    }
}

internal class Program
{
    static void Main()
    {
        BankAccount objAcc = new BankAccount();

        Console.Write("Enter amount to deposit: ");
        double depositAmount = Convert.ToDouble(Console.ReadLine());
        objAcc.Deposit(depositAmount);

        Console.Write("Enter amount to withdraw: ");
        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
        objAcc.Withdraw(withdrawAmount);

        Console.WriteLine("Current Balance = " + objAcc.GetBalance());
    }
}

