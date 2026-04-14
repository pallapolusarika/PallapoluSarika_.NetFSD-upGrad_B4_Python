namespace PolicyService.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public string PolicyType { get; set; }
        public decimal PremiumAmount { get; set; }
        public int CustomerId { get; set; }
    }
}
