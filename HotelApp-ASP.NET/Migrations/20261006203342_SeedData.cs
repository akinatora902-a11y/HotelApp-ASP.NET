using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelApp_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Capacity", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Compact room for one guest featuring a single bed, workspace desk, and private bathroom.", "Single Room" },
                    { 2, 2, "Cozy room with a queen-size bed, ideal for couples or solo travelers.", "Double Standard" },
                    { 3, 2, "Practical room with two separate single beds, suitable for friends or colleagues.", "Twin Room" },
                    { 4, 2, "Spacious room featuring a king-size bed, private balcony, and scenic view.", "Deluxe Double" },
                    { 5, 3, "Comfortable room equipped with three single beds or one double and one single bed.", "Triple Room" },
                    { 6, 4, "Large suite with two separate bedrooms, perfect for families traveling together.", "Family Suite" },
                    { 7, 3, "Elegant mini-suite featuring a sitting area, sofa, and upgraded bathroom amenities.", "Junior Suite" },
                    { 8, 2, "Premium suite tailored for business travelers, including a workspace and lounge access.", "Executive Suite" },
                    { 9, 4, "Top-floor luxury penthouse with panoramic views, private jacuzzi, and spacious terrace.", "Presidential Penthouse" },
                    { 10, 2, "Specially adapted room for guests with reduced mobility, featuring widened doorways and roll-in shower.", "Accessible Room" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "IsAvailable", "PricePerNight", "RoomNumber", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 1, true, 60.00m, 101, 1 },
                    { 2, 1, true, 90.00m, 102, 2 },
                    { 3, 1, false, 95.00m, 103, 3 },
                    { 4, 2, true, 130.00m, 201, 4 },
                    { 5, 2, true, 140.00m, 202, 5 },
                    { 6, 2, false, 200.00m, 203, 6 },
                    { 7, 3, true, 180.00m, 301, 7 },
                    { 8, 3, true, 250.00m, 302, 8 },
                    { 9, 4, true, 500.00m, 401, 9 },
                    { 10, 1, true, 85.00m, 104, 10 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckInDate", "CheckOutDate", "GuestEmail", "GuestName", "GuestPhone", "RoomId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John Doe", "+1234567890", 1, 300.00m },
                    { 2, new DateTime(2026, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane Smith", "+1234567891", 2, 180.00m },
                    { 3, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.brown@example.com", "Michael Brown", "+1234567892", 3, 665.00m },
                    { 4, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.davis@example.com", "Emily Davis", "+1234567893", 4, 520.00m },
                    { 5, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniel.wilson@example.com", "Daniel Wilson", "+1234567894", 5, 700.00m },
                    { 6, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.taylor@example.com", "Sarah Taylor", "+1234567895", 6, 1400.00m },
                    { 7, new DateTime(2026, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.anderson@example.com", "David Anderson", "+1234567896", 7, 1260.00m },
                    { 8, new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "jessica.thomas@example.com", "Jessica Thomas", "+1234567897", 8, 750.00m },
                    { 9, new DateTime(2026, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2027, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.white@example.com", "James White", "+1234567898", 9, 1500.00m },
                    { 10, new DateTime(2026, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "amanda.martin@example.com", "Amanda Martin", "+1234567899", 10, 255.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
