using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.Models
{
    //[PrimaryKey(nameof(TableId), nameof(ReservationID))]
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string TableNumber { get; set; }

        [Required]
        [Range(1, 12)]
        public int Capacity { get; set; }

        [Required]
        public int AreaId { get; set; }
        public Area Area { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        //public List<Reservation> Reservation { get; set; } = new List<Reservation>();
    }
}
