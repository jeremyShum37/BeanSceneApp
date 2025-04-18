using System.ComponentModel.DataAnnotations;

namespace BeanSceneApp.Models
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }

        [Required]
        public string AreaName { get; set; }

        public List<Table> Table { get; set; } = new List<Table>();
    }
}
