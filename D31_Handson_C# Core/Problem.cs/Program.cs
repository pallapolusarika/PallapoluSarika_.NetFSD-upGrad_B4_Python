/*Problem 1: Contact Management Web Application (Using Dependency Injection)
Scenario:
ABC Infotech wants to improve their application design by following best practices like Dependency Injection (DI). Instead of handling all logic inside the controller, they want to introduce a service layer to manage contact operations.
The application should still:
•	Add contacts 
•	View all contacts 
•	Search contact by ID 
But now using DI for better architecture.

Requirements:
1.Model Class
Create ContactInfo class with auto - implemented properties:
Name Type    Modifier
ContactId	int	public
FirstName string public
LastName string public
CompanyName string public
EmailId string public
MobileNo long public
Designation string public

2.Create Service Layer(DI Implementation)
Create:
🔸 Interface → IContactService
Include methods:
•	List<ContactInfo> GetAllContacts()
•	ContactInfo GetContactById(int id)
•	void AddContact(ContactInfo contact)
🔸 Implementation → ContactService
•	Maintain:
private static List<ContactInfo> contacts = new List<ContactInfo>();
Implement all methods:
•	Add contact to list 
•	Return all contacts 
•	Search contact by ID

3.Register Service in DI Container
In Program.cs:
builder.Services.AddSingleton<IContactService, ContactService>();
4.Controller: ContactController
Inject service using constructor injection:
5.Action Methods
Function	Description
ShowContacts()	Use _contactService.GetAllContacts() and display list in tabular format
GetContactById(int id)	Use _contactService.GetContactById(id) and display contact
AddContact()	Return view to accept contact details
[HttpPost] AddContact(ContactInfo contactInfo)  Call _contactService.AddContact(contactInfo) and redirect to ShowContacts

6. Startup Configuration
Set default route to:
•	Contact → ShowContacts
Technical Constraints
•	MUST use: 
o Dependency Injection 
o	Interface + Service class
o   Constructor Injection 
o	Attribute-based routing (optional but recommended) 

•	Do NOT use: 
o Database 
o	Static List inside Controller ❌ 
o	Business logic inside Controller ❌ 
•	Static List allowed ONLY inside Service class

Expectations
1.Proper DI implementation
2.Controller should ONLY: 
•	Receive request 
•	Call service 
•	Return response 
3. Service should: 
•	Handle all business logic 
•	Manage data 
4.  Clean separation of: 
•	Controller vs Service
Learning Outcome
After completing this problem, students will:
•	Understand Dependency Injection in ASP.NET Core MVC 
•	Learn: 
o Interface-based design 
o	Service layer implementation 
o	Constructor injection 
•	Realize: 
o Why fat controllers are bad 
o	How DI improves maintainability & testability */

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// DI registration
builder.Services.AddSingleton<IContactService, ContactService>();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=ShowContacts}/{id?}");

app.Run();
