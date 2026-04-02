using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
      
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
