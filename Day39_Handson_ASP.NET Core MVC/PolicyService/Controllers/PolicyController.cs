using Microsoft.AspNetCore.Mvc;
using PolicyService.Data;
using PolicyService.Models;

namespace PolicyService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolicyController : ControllerBase
    {
        private readonly PolicyDbContext _context;

        public PolicyController(PolicyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPolicies()
        {
            return Ok(_context.Policies.ToList());
        }

        [HttpPost]
        public IActionResult AddPolicy(Policy policy)
        {
            _context.Policies.Add(policy);
            _context.SaveChanges();
            return Ok(policy);
        }
    }
}
