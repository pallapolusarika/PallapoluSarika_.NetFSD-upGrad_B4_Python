/*Problem 3 (Level-2): Product Entry with List Display
Scenario:
An admin wants to add multiple products and view them in a list on the same page.
Requirements:
1.Create a form to input: 
•	Product Name 
•	Price 
•	Quantity 
2.  On submission: 
•	Add product to a List 
•	Display all products in tabular format 
3. Use ViewBag to store and display list
Technical Constraints
1.  Use Attribute-based routing 
2.  Use HttpPost for adding data 
3.  Maintain list temporarily (no database) 
4.  Use static list or TempData alternative NOT allowed
Expectations
1.  Data persists across multiple submissions (within session scope) 
2.  Table updates dynamically after each submission 
3.  Clean UI separation (form + table)
Learning Outcome
1.  Managing collections using ViewBag/ ViewData
2.Handling repeated form submissions 
3. Understanding limitations of ViewBag*/

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllers();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
