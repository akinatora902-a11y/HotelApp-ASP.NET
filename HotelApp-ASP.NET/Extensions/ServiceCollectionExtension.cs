using HotelApp.Corе.Contracts;
using HotelApp.Data;
using Microsoft.EntityFrameworkCore;
using HotelApp.Corе.Services;
using HotelApp.Common.Contract;
using HotelApp.Common.Service;


namespace HotelApp_ASP.NET.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IValidationService, ValidationService>();

            return services;
        }


        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<HotelDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
