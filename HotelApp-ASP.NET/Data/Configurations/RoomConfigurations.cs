using HotelApp_ASP.NET.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp_ASP.NET.Data.Configurations
{
    public class RoomConfigurations : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.HasData(
                new RoomEntity { Id = 1, RoomNumber = 101, Floor = 1, PricePerNight = 60.00m, IsAvailable = true, RoomTypeId = 1 },
                new RoomEntity { Id = 2, RoomNumber = 102, Floor = 1, PricePerNight = 90.00m, IsAvailable = true, RoomTypeId = 2 },
                new RoomEntity { Id = 3, RoomNumber = 103, Floor = 1, PricePerNight = 95.00m, IsAvailable = false, RoomTypeId = 3 },
                new RoomEntity { Id = 4, RoomNumber = 201, Floor = 2, PricePerNight = 130.00m, IsAvailable = true, RoomTypeId = 4 },
                new RoomEntity { Id = 5, RoomNumber = 202, Floor = 2, PricePerNight = 140.00m, IsAvailable = true, RoomTypeId = 5 },
                new RoomEntity { Id = 6, RoomNumber = 203, Floor = 2, PricePerNight = 200.00m, IsAvailable = false, RoomTypeId = 6 },
                new RoomEntity { Id = 7, RoomNumber = 301, Floor = 3, PricePerNight = 180.00m, IsAvailable = true, RoomTypeId = 7 },
                new RoomEntity { Id = 8, RoomNumber = 302, Floor = 3, PricePerNight = 250.00m, IsAvailable = true, RoomTypeId = 8 },
                new RoomEntity { Id = 9, RoomNumber = 401, Floor = 4, PricePerNight = 500.00m, IsAvailable = true, RoomTypeId = 9 },
                new RoomEntity { Id = 10, RoomNumber = 104, Floor = 1, PricePerNight = 85.00m, IsAvailable = true, RoomTypeId = 10 }
            );
        }
    }
}
