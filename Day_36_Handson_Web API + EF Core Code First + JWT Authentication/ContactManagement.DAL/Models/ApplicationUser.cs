using System.ComponentModel.DataAnnotations;

namespace ContactManagement.DAL.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}