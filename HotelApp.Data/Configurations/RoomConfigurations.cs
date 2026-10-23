using HotelApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelApp.Data.Configurations
{
    public class RoomConfigurations : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            builder.HasData(
                new RoomEntity { Id = 1, RoomNumber = 101, Floor = 1,  IsAvailable = true, RoomTypeId = 1 },
                new RoomEntity { Id = 2, RoomNumber = 102, Floor = 1,  IsAvailable = true, RoomTypeId = 2 },
                new RoomEntity { Id = 3, RoomNumber = 103, Floor = 1,  IsAvailable = false, RoomTypeId = 3 },
                new RoomEntity { Id = 4, RoomNumber = 201, Floor = 2, IsAvailable = true, RoomTypeId = 4 },
                new RoomEntity { Id = 5, RoomNumber = 202, Floor = 2,  IsAvailable = true, RoomTypeId = 5 },
                new RoomEntity { Id = 6, RoomNumber = 203, Floor = 2,  IsAvailable = false, RoomTypeId = 6 },
                new RoomEntity { Id = 7, RoomNumber = 301, Floor = 3,  IsAvailable = true, RoomTypeId = 7 },
                new RoomEntity { Id = 8, RoomNumber = 302, Floor = 3,  IsAvailable = true, RoomTypeId = 8 },
                new RoomEntity { Id = 9, RoomNumber = 401, Floor = 4,  IsAvailable = true, RoomTypeId = 9 },
                new RoomEntity { Id = 10, RoomNumber = 104, Floor = 1, IsAvailable = true, RoomTypeId = 10 }
            );
        }
    }
}
