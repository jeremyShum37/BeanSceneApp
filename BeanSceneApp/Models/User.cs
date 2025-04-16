using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set;}

        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [Required]
        public string Email { get; set; } = "";

        public string? Phone { get; set; }

        [Required]
        public string Password { get; set; } = "";

        public string? Image { get; set; }

        [Required]
        public string Role { get; set; } = "";
    }
}
