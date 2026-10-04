using System.ComponentModel.DataAnnotations;

namespace HotelApp_ASP.NET.Data.Models
{
    public class RoomTypeEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        
        public int Capacity { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<RoomEntity> Rooms { get; set; } = new HashSet<RoomEntity>();
    }
}
