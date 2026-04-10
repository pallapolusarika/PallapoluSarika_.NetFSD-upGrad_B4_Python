using System.ComponentModel.DataAnnotations;

namespace ContactManagement.DAL.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
