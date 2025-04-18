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
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public bool IsClosed { get; set; }

        public List<Reservation> Reservation { get; set; } = new List<Reservation>();
    }
}
