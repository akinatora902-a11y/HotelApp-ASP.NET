# 🚀 Project Name: Hotel-App

## 📋 Table of Contents

About the Project

HotelApp is a reservation management system for one hotel. Hotel staff can browse the rooms, check which rooms are free for a given period, and create or cancel guest bookings. 
Administrators can also manage the rooms themselves (add, edit, delete).
Technologies Used

* ASP.NET Core MVC (.NET 8)
* Entity Framework Core with SQL Server
* ASP.NET Core Identity (authentication and roles)
* Razor views with layout, partial views and sections
* Bootstrap 5 for responsive design
* jQuery Validation (client-side validation) and Data Annotations (server-side validation)
* Dependency Injection with a service layer built on interfaces

## ✅ Prerequisites

Make sure you have the following installed before running the project:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) or SQLite (if used)
- [Git](https://git-scm.com/)

## 🚀 Getting Started
### 1. Clone the repository

```bash
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Apply database migrations

```bash
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run
```

The app will be available at `https://localhost:5001` or `http://localhost:5000`.

## 📁 Project Structure

```
HotelApp-ASP.NET/
├── HotelApp.Common/        # Shared constants and helper services
│   ├── Contract/           #   IValidationService
│   ├── Service/            #   ValidationService
│   └── ValidationConstants/#   EntityValidation, AppValidation
├── HotelApp.Core/          # Business logic
│   ├── Contracts/          #   IBookingService, IRoomService, ITypeService
│   ├── Services/           #   Service implementations
│   └── DataTransferObjects/#   DTOs
├── HotelApp.Data/          # Data access
│   ├── Models/             #   RoomEntity, RoomTypeEntity, BookingEntity, ApplicationUser
│   ├── Configurations/     #   Entity configurations and seed data
│   ├── Migrations/         #   EF Core migrations
│   └── HotelDbContext.cs
└── HotelApp-ASP.NET/       # Web (MVC) project
    ├── Controllers/        #   Home, Room, Booking
    ├── ViewModels/
    ├── Views/              #   Home, Room, Booking, Shared
    ├── Extensions/         #   Service registration
    └── Program.cs

---

## ✨ Features
- [ ] Rooms: full CRUD (create, list, details, edit, delete)
- [ ] Bookings: list, details, create and cancel reservations
- [ ] Room types loaded from the database into dropdown lists
- [ ] Automatic total price calculation based on nights and room price
- [ ] Validation:
   * Server-side: Data Annotations and ModelState
   * Client-side: jQuery Validation (_ValidationScriptsPartial)
   * Validation limits are centralized in EntityValidation
- [ ] Authentication and roles with ASP.NET Core Identity
- [ ] Seed data: 10 room types, 10 rooms and 10 sample bookings are created by the first migration
- [ ] Responsive UI built with Bootstrap

---

## 💻 Usage

### Test accounts

The roles `Admin` and `User` and the administrator account below are created automatically when the application starts.

| Role  | Email         | Password |
|-------|---------------|----------|
| Admin | `main@abv.bg` | `123456` |

Newly registered users do not receive the `Admin` role.

### Permissions

| Action                      | User | Admin |
|-----------------------------|:----:|:-----:|
| View rooms and room details |  ✅  |  ✅   |
| Create / view / cancel bookings | ✅ | ✅  |
| Create / edit / delete rooms |  ❌  |  ✅   |

## Database Setup

The project uses SQL Server. The migrations are in `HotelApp.Data`, and the web project is the startup project.

**Using the .NET CLI** (run from the solution folder):

```bash
dotnet ef database update --project HotelApp.Data --startup-project HotelApp-ASP.NET
```

**Using Visual Studio Package Manager Console:**

- Default project: `HotelApp.Data`
- Startup project: `HotelApp-ASP.NET`

```powershell
Update-Database
```

The database and the seed data are created automatically.

## Configuration

Connection string in `HotelApp-ASP.NET/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=HotelAppDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

If you use a full SQL Server instance, change `Server=` to your server name. No other environment variables are required for local testing.

## Contributing

This is a course project and is not open for contributions at the moment.

## License

This project was created for educational purposes.

## Contact

- **Author:** `<Alexander Petrov>`
- **GitHub:** [`<akinatora902-a11y>`]
- **Email:** `<akinatora902@gmail.com>`
