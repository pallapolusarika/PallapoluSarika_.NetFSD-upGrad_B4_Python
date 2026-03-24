Problem 6- Implementing Factory Pattern
Scenario: Notification Service
A company application sends notifications to users using different communication channels:
•	Email
•	SMS
•	Push Notification
The application should not directly create objects using new.
Instead, a Factory class should determine which notification service to create.
Students must implement:
•	Interface
INotification
•	Method:
		Send(string message)
Classes
•	EmailNotification
•	SMSNotification
•	PushNotification
Each class should implement INotification.
Factory Class
NotificationFactory
Method:
CreateNotification(string type)
Example:
CreateNotification("email")
CreateNotification("sms")
CreateNotification("push")
Technical Constraints
•	Use interface-based design.
•	Client should not instantiate concrete classes directly.
•	Use Factory Pattern to create objects.
•	Language: C# Console Application.
Expectations:
Students should demonstrate:
NotificationFactory factory = new NotificationFactory();
var notification = factory.CreateNotification("email");
notification.Send("Welcome to our service!");
Learning Outcome:
Students will learn:
•	Decoupling object creation from usage
•	Interface-based programming
•	Open/Closed Principle basics
•	Real-world object creation management

class Program
{
    static void Main(string[] args)
    {
        NotificationFactory factory = new NotificationFactory();

        Console.WriteLine("Enter type (email/sms/push):");
        string type = Console.ReadLine();

        INotification notification = factory.CreateNotification(type);

        Console.WriteLine("Enter message:");
        string msg = Console.ReadLine();

        notification.Send(msg);

        Console.ReadLine();
    }
}
