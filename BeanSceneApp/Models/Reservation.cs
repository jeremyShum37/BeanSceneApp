using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneApp.Models
{
    public class Reservation
    {
        [Column(TypeName = "int")]
        [Key]
        public int ReservationId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string GuestName { get; set; } = "";

        [Column(TypeName = "varchar(100)")]
        public string? Email { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Phone { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        
        [Required]
        [Range(15, 480)]
        public int Duration { get; set; }
        
        [Required]
        [Range(1, 20)]
        public int GuestCount { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Status{ get; set; } = "Pending";

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Source { get; set; } = "";

        public string? Notes { get; set; }

        public List<Table> Table { get; set; } = new List<Table>();

        public int SittingId { get; set; }
        public Sitting? Sitting { get; set; }

        public int? MemberId { get; set; }
        public Member? Member { get; set; }
    }
}
