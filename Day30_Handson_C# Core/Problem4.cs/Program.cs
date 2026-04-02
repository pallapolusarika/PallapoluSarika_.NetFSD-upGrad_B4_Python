/*Problem 4 (Level-2): Feedback Form with Conditional Message
Scenario:
A website collects user feedback and displays different messages based on rating.
Requirements:
1.Create a feedback form: 
•	Name
•	Comments 
•	Rating (1–5) 
2.  Submit using HttpPost 
3.After submission:
•	Show “Thank You” message if rating ≥ 4 
•	Show “We will improve” message if rating < 4 
4.  Use ViewData to pass message
Technical Constraints
1.  Use Attribute routing 
2.  Do NOT use TempData/Session 
3. Do NOT use database 
4. Must use ViewData for message handling
Expectations
1.  Correct conditional logic 
2.  Proper use of ViewData 
3.  Clean routing structure
Learning Outcome
1. Conditional rendering using server-side logic
2. Using ViewData for dynamic UI behavior 
3.  Reinforcing form handling c*/

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

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();