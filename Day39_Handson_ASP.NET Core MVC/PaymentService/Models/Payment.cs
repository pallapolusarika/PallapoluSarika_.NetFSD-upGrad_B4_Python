namespace PaymentService.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public decimal Amount { get; set; }   // 💰 Payment amount

        public DateTime PaymentDate { get; set; }

        public string PaymentStatus { get; set; }
    }
}