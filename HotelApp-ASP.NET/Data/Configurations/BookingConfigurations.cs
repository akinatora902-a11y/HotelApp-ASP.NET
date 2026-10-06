using HotelApp_ASP.NET.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp_ASP.NET.Data.Configurations
{
    public class BookingConfigurations : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.HasData(
                new BookingEntity
                {
                    Id = 1,
                    GuestName = "John Doe",
                    GuestEmail = "john.doe@example.com",
                    GuestPhone = "+1234567890",
                    CheckInDate = new DateTime(2026, 10, 10),
                    CheckOutDate = new DateTime(2026, 10, 15),
                    TotalPrice = 300.00m,
                    RoomId = 1
                },
                new BookingEntity
                {
                    Id = 2,
                    GuestName = "Jane Smith",
                    GuestEmail = "jane.smith@example.com",
                    GuestPhone = "+1234567891",
                    CheckInDate = new DateTime(2026, 10, 12),
                    CheckOutDate = new DateTime(2026, 10, 14),
                    TotalPrice = 180.00m,
                    RoomId = 2
                },
                new BookingEntity
                {
                    Id = 3,
                    GuestName = "Michael Brown",
                    GuestEmail = "michael.brown@example.com",
                    GuestPhone = "+1234567892",
                    CheckInDate = new DateTime(2026, 10, 05),
                    CheckOutDate = new DateTime(2026, 10, 12),
                    TotalPrice = 665.00m,
                    RoomId = 3
                },
                new BookingEntity
                {
                    Id = 4,
                    GuestName = "Emily Davis",
                    GuestEmail = "emily.davis@example.com",
                    GuestPhone = "+1234567893",
                    CheckInDate = new DateTime(2026, 11, 01),
                    CheckOutDate = new DateTime(2026, 11, 05),
                    TotalPrice = 520.00m,
                    RoomId = 4
                },
                new BookingEntity
                {
                    Id = 5,
                    GuestName = "Daniel Wilson",
                    GuestEmail = "daniel.wilson@example.com",
                    GuestPhone = "+1234567894",
                    CheckInDate = new DateTime(2026, 10, 20),
                    CheckOutDate = new DateTime(2026, 10, 25),
                    TotalPrice = 700.00m,
                    RoomId = 5
                },
                new BookingEntity
                {
                    Id = 6,
                    GuestName = "Sarah Taylor",
                    GuestEmail = "sarah.taylor@example.com",
                    GuestPhone = "+1234567895",
                    CheckInDate = new DateTime(2026, 10, 01),
                    CheckOutDate = new DateTime(2026, 10, 08),
                    TotalPrice = 1400.00m,
                    RoomId = 6
                },
                new BookingEntity
                {
                    Id = 7,
                    GuestName = "David Anderson",
                    GuestEmail = "david.anderson@example.com",
                    GuestPhone = "+1234567896",
                    CheckInDate = new DateTime(2026, 12, 20),
                    CheckOutDate = new DateTime(2026, 12, 27),
                    TotalPrice = 1260.00m,
                    RoomId = 7
                },
                new BookingEntity
                {
                    Id = 8,
                    GuestName = "Jessica Thomas",
                    GuestEmail = "jessica.thomas@example.com",
                    GuestPhone = "+1234567897",
                    CheckInDate = new DateTime(2026, 10, 15),
                    CheckOutDate = new DateTime(2026, 10, 18),
                    TotalPrice = 750.00m,
                    RoomId = 8
                },
                new BookingEntity
                {
                    Id = 9,
                    GuestName = "James White",
                    GuestEmail = "james.white@example.com",
                    GuestPhone = "+1234567898",
                    CheckInDate = new DateTime(2026, 12, 30),
                    CheckOutDate = new DateTime(2027, 01, 02),
                    TotalPrice = 1500.00m,
                    RoomId = 9
                },
                new BookingEntity
                {
                    Id = 10,
                    GuestName = "Amanda Martin",
                    GuestEmail = "amanda.martin@example.com",
                    GuestPhone = "+1234567899",
                    CheckInDate = new DateTime(2026, 10, 18),
                    CheckOutDate = new DateTime(2026, 10, 21),
                    TotalPrice = 255.00m,
                    RoomId = 10
                }
            );
        }
    }
}
