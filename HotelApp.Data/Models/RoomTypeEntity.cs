using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelApp.Common.ValidationConstants.EntityValidation;

namespace HotelApp.Data.Models
{
    public class RoomTypeEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(RoomTypeNameMaxLength, MinimumLength = RoomTypeNameMinLength)]
        public string Name { get; set; }
        
        public int Capacity { get; set; }

        [StringLength(RoomTypeDescriptionMaxLength)]
        public string? Description { get; set; }

        public virtual ICollection<RoomEntity> Rooms { get; set; } = new HashSet<RoomEntity>();
    }
}
