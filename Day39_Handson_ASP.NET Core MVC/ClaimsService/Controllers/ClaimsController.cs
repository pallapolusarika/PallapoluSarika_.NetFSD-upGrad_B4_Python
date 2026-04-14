using Microsoft.AspNetCore.Mvc;
using ClaimsService.Data;
using ClaimsService.Models;

namespace ClaimsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly ClaimsDbContext _context;

        public ClaimsController(ClaimsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClaims()
        {
            return Ok(_context.Claims.ToList());
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            claim.Status = "Pending";
            _context.Claims.Add(claim);
            _context.SaveChanges();
            return Ok(claim);
        }

        [HttpPut("{id}/approve")]
        public IActionResult ApproveClaim(int id)
        {
            var claim = _context.Claims.Find(id);

            if (claim == null)
                return NotFound("Claim not found");

            claim.Status = "Approved";
            _context.SaveChanges();

            return Ok(claim);
        }

        [HttpPut("{id}/reject")]
        public IActionResult RejectClaim(int id)
        {
            var claim = _context.Claims.Find(id);

            if (claim == null)
                return NotFound("Claim not found");

            claim.Status = "Rejected";
            _context.SaveChanges();

            return Ok(claim);
        }
    }
}
