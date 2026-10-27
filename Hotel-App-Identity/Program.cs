using HotelApp.Common.Contract;
using HotelApp.Common.Service;
using HotelApp.Corе.Contracts;
using HotelApp.Corе.Services;
using HotelApp.Data;
using HotelApp_ASP.NET.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HotelDbContext") ?? throw new InvalidOperationException("Connection string 'HotelDbContext' not found.");

builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddControllersWithViews();

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);
builder.Services.AddRazorPages();
builder.Services.AddApplicationServices();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<ITypeService, TypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

await app.SeedRolesAsync();
await app.SeedAdminAsync();

app.Run();
