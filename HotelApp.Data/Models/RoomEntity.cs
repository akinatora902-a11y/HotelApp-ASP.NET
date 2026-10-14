using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApp.Data.Models
{
    public class RoomEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public int Floor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerNight { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
        public int RoomTypeId { get; set; }

        [ForeignKey(nameof(RoomTypeId))]
        public virtual RoomTypeEntity RoomType { get; set; } = null!;

        public virtual ICollection<BookingEntity> Bookings { get; set; } = new HashSet<BookingEntity>();
    }   
}
