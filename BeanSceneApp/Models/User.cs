using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.Models
{
    public abstract class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [Required]
        [NotMapped]
        public string? Password { get; set; }

        public string? Image { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
