using HotelApp_ASP.NET.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HotelApp_ASP.NET.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }
        public DbSet<Models.RoomTypeEntity> RoomTypes { get; set; } = null!;
        public DbSet<Models.RoomEntity> Rooms { get; set; } = null!;
        public DbSet<Models.BookingEntity> Bookings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingConfigurations());
            modelBuilder.ApplyConfiguration(new RoomConfigurations());
            modelBuilder.ApplyConfiguration(new RoomTypeConfigurations());
        }
    }
}
