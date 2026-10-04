using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApp_ASP.NET.Data.Models
{
    public class BookingEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string GuestName { get; set; }

        [EmailAddress]
        public string GuestEmail { get; set; }

        [Required]
        [Phone] 
        public string GuestPhone { get; set; } = null!;

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public int RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public virtual RoomEntity Room { get; set; } = null!;
    }
}
