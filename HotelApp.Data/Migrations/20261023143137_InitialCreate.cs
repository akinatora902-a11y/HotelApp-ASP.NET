using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GuestEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GuestPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "date", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "date", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Capacity", "Description", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { 1, 1, "Compact room for one guest featuring a single bed, workspace desk, and private bathroom.", "Single Room", 60.00m },
                    { 2, 2, "Cozy room with a queen-size bed, ideal for couples or solo travelers.", "Double Standard", 90.00m },
                    { 3, 2, "Practical room with two separate single beds, suitable for friends or colleagues.", "Twin Room", 95.00m },
                    { 4, 2, "Spacious room featuring a king-size bed, private balcony, and scenic view.", "Deluxe Double", 130.00m },
                    { 5, 3, "Comfortable room equipped with three single beds or one double and one single bed.", "Triple Room", 140.00m },
                    { 6, 4, "Large suite with two separate bedrooms, perfect for families traveling together.", "Family Suite", 200.00m },
                    { 7, 3, "Elegant mini-suite featuring a sitting area, sofa, and upgraded bathroom amenities.", "Junior Suite", 180.00m },
                    { 8, 2, "Premium suite tailored for business travelers, including a workspace and lounge access.", "Executive Suite", 250.00m },
                    { 9, 4, "Top-floor luxury penthouse with panoramic views, private jacuzzi, and spacious terrace.", "Presidential Penthouse", 500.00m },
                    { 10, 2, "Specially adapted room for guests with reduced mobility, featuring widened doorways and roll-in shower.", "Accessible Room", 85.00m }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "IsAvailable", "RoomNumber", "RoomTypeId" },
                values: new object[,]
                {
                    { 1, 1, true, 101, 1 },
                    { 2, 1, true, 102, 2 },
                    { 3, 1, false, 103, 3 },
                    { 4, 2, true, 201, 4 },
                    { 5, 2, true, 202, 5 },
                    { 6, 2, false, 203, 6 },
                    { 7, 3, true, 301, 7 },
                    { 8, 3, true, 302, 8 },
                    { 9, 4, true, 401, 9 },
                    { 10, 1, true, 104, 10 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
