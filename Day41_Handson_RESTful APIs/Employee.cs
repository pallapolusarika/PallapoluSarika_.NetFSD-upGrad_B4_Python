using System.ComponentModel.DataAnnotations;

namespace ApiTestingDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Department { get; set; } = string.Empty;

        [Range(1, 1000000)]
        public decimal Salary { get; set; }
    }
}
