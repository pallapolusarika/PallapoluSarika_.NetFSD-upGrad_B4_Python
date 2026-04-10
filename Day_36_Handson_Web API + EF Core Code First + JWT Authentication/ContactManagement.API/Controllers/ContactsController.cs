using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetContacts()
        {
            return Ok("Contacts API is working and Authorized");
        }
    }
}