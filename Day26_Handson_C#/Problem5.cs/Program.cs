/*Problem 5- Implementing Singleton Pattern
Scenario: Application Configuration Manager
A company is developing a console-based inventory management system.
The application needs to read application settings (e.g., database connection string, app name, version) from a configuration manager.
Since configuration settings should be loaded only once and shared across the entire application, multiple instances of the configuration manager must be prevented.
Therefore, the development team decides to implement the Singleton Design Pattern.

Program Flow Diagram:
 
Requirements:
Students must implement:
1.A class named ConfigurationManager
2.	Ensure only one instance of the class can be created.
3.Provide a method:
GetInstance()
to retrieve the single object.
4.	Store configuration values such as:
•	ApplicationName
•	Version
•	DatabaseConnectionString
5.	Demonstrate that multiple calls to GetInstance() return the same instance.

Technical Constraints:
•	Use private constructor.
•	Use static instance variable.
•	Use thread-safe implementation (basic level optional).
•	Console application using C# (.NET).
Expectations:
Students should:
•	Prevent object creation using new.
•	Access instance using:
	ConfigurationManager.GetInstance()
•	Print configuration details from multiple method calls.
Learning Outcome:
After completing this problem, learners will understand:
•	Why Singleton is used
•	How to restrict object creation
•	Global shared objects*/

using System;
class ConfigurationManager
{
    private static ConfigurationManager instance;
    public string ApplicationName { get; set; }
    public string Version { get; set; }
    public string DatabaseConnectionString { get; set; }
    private ConfigurationManager()
    {
        ApplicationName = "Inventory App";
        Version = "1.0";
        DatabaseConnectionString = "Server=.;Database=InventoryDB;Trusted_Connection=True;";
    }
    public static ConfigurationManager GetInstance()
    {
        if (instance == null)
        {
            instance = new ConfigurationManager();
        }
        return instance;
    }
}
class Program
{
    static void Main()
    {
        var config1 = ConfigurationManager.GetInstance();
        Console.WriteLine("First Call:");
        Console.WriteLine(config1.ApplicationName);
        Console.WriteLine(config1.Version);
        Console.WriteLine(config1.DatabaseConnectionString);
        Console.WriteLine("----------------------");
        var config2 = ConfigurationManager.GetInstance();

        Console.WriteLine("Second Call:");
        Console.WriteLine(config2.ApplicationName);
        Console.WriteLine(config2.Version);
        Console.WriteLine(config2.DatabaseConnectionString);
        Console.WriteLine("----------------------");
        if (config1 == config2)
        {
            Console.WriteLine("Same Instance (Singleton Works!)");
        }
        else
        {
            Console.WriteLine("Different Instances");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}