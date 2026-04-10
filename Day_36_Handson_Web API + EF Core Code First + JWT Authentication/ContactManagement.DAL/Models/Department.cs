using System.ComponentModel.DataAnnotations;

namespace ContactManagement.DAL.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        public ICollection<ContactInfo> Contacts { get; set; }
    }
}