/*Problem: CRUD Operations using ADO.NET and SQL Server with Secure Code Practices.
Scenario:
You are developing a small Product Management module for an inventory system.
The application should allow users to add, view, update, and delete product records stored in a SQL Server database.
Since this module will be part of a real enterprise application, it must follow secure coding practices to prevent vulnerabilities such as SQL Injection attacks and protect sensitive configuration data.
You need to implement the CRUD operations using ADO.NET with SQL Server stored procedures while ensuring best practices for database connectivity and security.

Database Table Structure
Table Name: Products
Column Name	Data Type	Description
ProductId	INT (Primary Key, Identity)	Unique ID of product
ProductName	VARCHAR(100)	Name of the product
Category	VARCHAR(50)	Product category
Price	DECIMAL(10,2)	Product price





Requirements:
Your application should support the following operations:
1.Insert Product
•	Accept product details from user input
•	Store product in database using stored procedure
2.View All Products
•	Retrieve and display all product records
3. Update Product
•	Allow modification of:
o ProductName
o	Category
o	Price
o	Stock
4. Delete Product
•	Delete product using ProductId


Security Requirements(Secure Coding Practices)
Students must implement the following security measures:
1.Prevent SQL Injection
•	Do NOT write inline SQL queries
•	Use stored procedures
•	Use SqlParameter objects
2. Secure Connection String
•	Store connection string in appsettings.json
•	Do not hardcode connection string inside the code.
3. Use Proper Resource Handling
•	Use using statement to automatically close connections

Technical Constraints:
Students must follow these constraints:
1.Use C# Console Application (.NET 8)
2.	Use ADO.NET classes
o	SqlConnection
o	SqlCommand
o	SqlDataReader
3.	All CRUD operations must use Stored Procedures
4.	Connection string must be stored in appsettings.json
5.	Use parameterized queries
6.	Use proper exception handling
7.	Follow layered structure if possible:
o Model
o	Data Access Class
o	Program
Expected Stored Procedures
Students should create stored procedures such as:
•	sp_InsertProduct
•	sp_GetAllProducts
•	sp_UpdateProduct
•	sp_DeleteProduct

Expectations:
Students should demonstrate the following:
•	Correct use of ADO.NET objects
•	Ability to call stored procedures
•	Implementation of secure coding practices
•	Clean and readable code
•	Proper handling of database connections
•	Meaningful console output for operations

Learning Outcome:
After completing this assignment, students will be able to:
1.Understand ADO.NET architecture and components
2.	Perform CRUD operations using SQL Server
3.Implement stored procedures with C#
4.	Prevent SQL Injection vulnerabilities
5.	Secure database configuration using appsettings.json
6.Write production - style database interaction code*/

using System;
using ProductApp.Models;
using ProductApp.Data;

class Program
{
    static void Main()
    {
        ProductRepository repo = new ProductRepository();

        while (true)
        {
            Console.WriteLine("\n1.Insert\n2.View\n3.Update\n4.Delete\n5.Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Product p = new Product();

                    Console.Write("Name: ");
                    p.ProductName = Console.ReadLine();

                    Console.Write("Category: ");
                    p.Category = Console.ReadLine();

                    Console.Write("Price: ");
                    p.Price = decimal.Parse(Console.ReadLine());

                    repo.Insert(p);
                    Console.WriteLine("Inserted!");
                    break;

                case 2:
                    repo.GetAll();
                    break;

                case 3:
                    Product up = new Product();

                    Console.Write("ID: ");
                    up.ProductId = int.Parse(Console.ReadLine());

                    Console.Write("New Name: ");
                    up.ProductName = Console.ReadLine();

                    Console.Write("New Category: ");
                    up.Category = Console.ReadLine();

                    Console.Write("New Price: ");
                    up.Price = decimal.Parse(Console.ReadLine());

                    repo.Update(up);
                    Console.WriteLine("Updated!");
                    break;

                case 4:
                    Console.Write("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());

                    repo.Delete(id);
                    Console.WriteLine("Deleted!");
                    break;

                case 5:
                    return;
            }
        }
    }
}