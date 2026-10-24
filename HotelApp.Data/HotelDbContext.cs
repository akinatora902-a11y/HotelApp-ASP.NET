using HotelApp.Data.Configurations;
using HotelApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HotelApp.Data
{
    public class HotelDbContext : IdentityDbContext<ApplicationUser>
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }
        public DbSet<Models.RoomTypeEntity> RoomTypes { get; set; } = null!;
        public DbSet<Models.RoomEntity> Rooms { get; set; } = null!;
        public DbSet<Models.BookingEntity> Bookings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookingConfigurations());
            modelBuilder.ApplyConfiguration(new RoomConfigurations());
            modelBuilder.ApplyConfiguration(new RoomTypeConfigurations());
        }
    }
}
