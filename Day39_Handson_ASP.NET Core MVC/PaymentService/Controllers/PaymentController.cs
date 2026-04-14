using Microsoft.AspNetCore.Mvc;
using PaymentService.Data;
using PaymentService.Models;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentDbContext _context;

        public PaymentController(PaymentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPayments()
        {
            return Ok(_context.Payments.ToList());
        }

        [HttpPost]
        public IActionResult MakePayment(Payment payment)
        {
            payment.PaymentDate = DateTime.Now;
            payment.PaymentStatus = "Paid";

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return Ok(payment);
        }
    }
}