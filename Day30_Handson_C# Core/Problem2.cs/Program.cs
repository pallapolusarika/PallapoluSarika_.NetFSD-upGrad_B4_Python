/*Problem 1 (Level-1): Simple Calculator
Scenario:
Build a simple calculator web page that performs addition of two numbers.
Requirements:
1.Accept two numbers using a form
2.Submit using HttpPost 
3.Display result on the same or another page 
3. Pass result using ViewData
Technical Constraints
1. Use Attribute routing 
2.  No JavaScript (pure server-side processing) 
3.  No Model binding (use form collection or parameters)
Expectations
1. Correct calculation logic 
2.  Proper HttpPost handling 
3.  Result displayed using ViewData
Learning Outcome
1.  Handling user input via forms 
2. Passing computed values using ViewData 
3.Understanding request lifecycle*/

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
