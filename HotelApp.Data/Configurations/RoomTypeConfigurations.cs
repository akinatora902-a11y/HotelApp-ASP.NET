using HotelApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Data.Configurations
{
    public class RoomTypeConfigurations : IEntityTypeConfiguration<RoomTypeEntity>
    {
        public void Configure(EntityTypeBuilder<RoomTypeEntity> builder)
        {
            builder.HasData(
                new RoomTypeEntity
                {
                    Id = 1,
                    Name = "Single Room",
                    Capacity = 1,
                    PricePerNight = 60.00m,
                    Description = "Compact room for one guest featuring a single bed, workspace desk, and private bathroom.",
                },
                new RoomTypeEntity
                {
                    Id = 2,
                    Name = "Double Standard",
                    Capacity = 2,
                    PricePerNight = 90.00m,
                    Description = "Cozy room with a queen-size bed, ideal for couples or solo travelers.",
                },
                new RoomTypeEntity
                {
                    Id = 3,
                    Name = "Twin Room",
                    Capacity = 2,
                    PricePerNight = 95.00m,
                    Description = "Practical room with two separate single beds, suitable for friends or colleagues.",
                },
                new RoomTypeEntity
                {
                    Id = 4,
                    Name = "Deluxe Double",
                    Capacity = 2,
                    PricePerNight = 130.00m,
                    Description = "Spacious room featuring a king-size bed, private balcony, and scenic view.",
                },
                new RoomTypeEntity
                {
                    Id = 5,
                    Name = "Triple Room",
                    Capacity = 3,
                    PricePerNight = 140.00m,
                    Description = "Comfortable room equipped with three single beds or one double and one single bed.",
                },
                new RoomTypeEntity
                {
                    Id = 6,
                    Name = "Family Suite",
                    Capacity = 4,
                    PricePerNight = 200.00m,
                    Description = "Large suite with two separate bedrooms, perfect for families traveling together.",
                },
                new RoomTypeEntity
                {
                    Id = 7,
                    Name = "Junior Suite",
                    Capacity = 3,
                    PricePerNight = 180.00m,
                    Description = "Elegant mini-suite featuring a sitting area, sofa, and upgraded bathroom amenities.",
                },
                new RoomTypeEntity
                {
                    Id = 8,
                    Name = "Executive Suite",
                    Capacity = 2,
                    PricePerNight = 250.00m,
                    Description = "Premium suite tailored for business travelers, including a workspace and lounge access.",
                },
                new RoomTypeEntity
                {
                    Id = 9,
                    Name = "Presidential Penthouse",
                    Capacity = 4,
                    PricePerNight = 500.00m,
                    Description = "Top-floor luxury penthouse with panoramic views, private jacuzzi, and spacious terrace.",
                },
                new RoomTypeEntity
                {
                    Id = 10,
                    Name = "Accessible Room",
                    Capacity = 2,
                    PricePerNight = 85.00m,
                    Description = "Specially adapted room for guests with reduced mobility, featuring widened doorways and roll-in shower.",
                }
            );
        }
    }
}
