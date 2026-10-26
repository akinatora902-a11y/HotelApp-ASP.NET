using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelApp.Common.ValidationConstants.EntityValidation;

namespace HotelApp.Data.Models
{
    public class RoomEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(RoomNumberMinValue, RoomNumberMaxValue)]
        public int RoomNumber { get; set; }

        [Required]
        [Range(FloorMinValue, FloorMaxValue)]
        public int Floor { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
        public int RoomTypeId { get; set; }

        [ForeignKey(nameof(RoomTypeId))]
        public virtual RoomTypeEntity RoomType { get; set; } = null!;

        public virtual ICollection<BookingEntity> Bookings { get; set; } = new HashSet<BookingEntity>();
    }
}
