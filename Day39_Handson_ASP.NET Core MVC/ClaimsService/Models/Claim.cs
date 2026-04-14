namespace ClaimsService.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public string ClaimReason { get; set; }
        public decimal ClaimAmount { get; set; }
        public string Status { get; set; }
    }
}