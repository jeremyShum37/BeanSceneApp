using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.Models
{
    public class Member : User
    {
        [Required]
        public DateTime JoinDate { get; set; } = new DateTime();

        public DateTime LastLogin { get; set; }

        public List<Reservation> Reservation { get; set; } = new List<Reservation>();
    }
}