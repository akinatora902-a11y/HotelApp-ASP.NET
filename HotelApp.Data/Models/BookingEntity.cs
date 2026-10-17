using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelApp.Common.ValidationConstants.EntityValidation;

namespace HotelApp.Data.Models
{
    public class BookingEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GuestNameMaxLength, MinimumLength = GuestNameMinLength)]
        public string GuestName { get; set; }

        [EmailAddress]
        [StringLength(GuestEmailMaxLength, MinimumLength = GuestEmailMinLength)]
        public string GuestEmail { get; set; }

        [Required]
        [Phone]
        [StringLength(GuestPhoneMaxLength, MinimumLength = GuestPhoneMinLength)]
        public string GuestPhone { get; set; } = null!;

        [Required]
        [Column(TypeName = "date")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime CheckOutDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public int RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public virtual RoomEntity Room { get; set; } = null!;
    }
}
