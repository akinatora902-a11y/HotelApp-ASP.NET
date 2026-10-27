using HotelApp.Common.Contract;
using HotelApp.Common.Service;
using HotelApp.Corе.Contracts;
using HotelApp.Corе.Services;
using HotelApp.Data;
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
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<HotelDbContext>();

            return services;
        }

        public static async Task SeedRolesAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var roleManager = scope.ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task SeedAdminAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var userManager = scope.ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            string email = "main@abv.bg";
            string password = "123456";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new IdentityUser
                {
                    UserName = email,
                    Email = email
                };

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
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
