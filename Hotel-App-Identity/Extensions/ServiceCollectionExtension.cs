using HotelApp.Common.Contract;
using HotelApp.Common.Service;
using HotelApp.Corе.Contracts;
using HotelApp.Corе.Services;
using HotelApp.Data;
using HotelApp.Data.Models;
using Microsoft.AspNetCore.Identity;
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

		public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDefaultIdentity<IdentityUser>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequiredLength = 3;
			})
			.AddEntityFrameworkStores<HotelDbContext>();

			return services;
		}

		private static void ConfigureIdentityOptions(IdentityOptions options, IConfiguration configuration)
		{
			options.Password.RequireLowercase =
				configuration.GetValue<bool>("Identity:Password:RequireLowercase");
			options.Password.RequireDigit =
				configuration.GetValue<bool>("Identity:Password:RequireDigit");
			options.Password.RequireUppercase =
				configuration.GetValue<bool>("Identity:Password:RequireUppercase");
			options.Password.RequiredUniqueChars =
				configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");
			options.Password.RequiredLength =
				configuration.GetValue<int>("Identity:Password:RequiredLength");
			options.Password.RequireNonAlphanumeric =
				configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

			options.SignIn.RequireConfirmedAccount =
				configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
			options.User.RequireUniqueEmail =
				configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
		}

	}
}
