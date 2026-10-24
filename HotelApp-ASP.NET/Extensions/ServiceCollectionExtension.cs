using HotelApp.Common.Contract;
using HotelApp.Common.Service;
using HotelApp.Corе.Contracts;
using HotelApp.Corе.Services;
using HotelApp.Data;
using HotelApp.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace HotelApp_ASP.NET.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<ITypeService, TypeService>();

            return services;
        }


        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<HotelDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<HotelDbContext>();

            return services;
        }
    }
}
