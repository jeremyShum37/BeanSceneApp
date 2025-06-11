using System.ComponentModel.DataAnnotations;

namespace BeanSceneApp.Models
{
    public class Sitting
    {
        [Key]
        public int SittingId { get; set; }

        [Required]
        public string SittingType { get; set; } // Breakfast/Lunch/Dinner

        [Required]
        public string TableCode { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public bool IsClosed { get; set; }

        public List<Reservation> Reservation { get; set; } = new List<Reservation>();
    }
}
