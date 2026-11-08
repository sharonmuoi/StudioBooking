# StudioBooking

Starter project for a photography / videography studio booking platform.

## Technology
- Frontend: React + Vite + Tailwind CSS
- Backend: ASP.NET Core Web API (.NET 8)
- Layers: API -> BUS -> DAL -> DTO
- Database: SQL Server + Entity Framework Core

## Requirements
- Node.js 20+
- .NET SDK 8
- SQL Server (LocalDB, SQL Server Express, or SQL Server)
- Visual Studio Code

## 1. Configure the database
Edit `Backend/StudioBooking.API/appsettings.json` and set `ConnectionStrings:DefaultConnection` to your SQL Server instance.

Example for SQL Server Express:
```json
"DefaultConnection": "Server=.\\SQLEXPRESS;Database=StudioBookingDb;Trusted_Connection=True;TrustServerCertificate=True;"
```

## 2. Run the backend
Open a terminal in `Backend/StudioBooking.API`:
```bash
dotnet restore
dotnet run
```

The API uses `http://localhost:5080` and `https://localhost:7080` when launched with the supplied launch settings. Swagger is available in Development at `/swagger`.

To create the database from EF Core migrations (after installing the EF tool if needed):
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 3. Run the frontend
Open another terminal in `Frontend`:
```bash
npm install
npm run dev
```

Open the URL printed by Vite (normally `http://localhost:5173`). The frontend calls `http://localhost:5080/api` by default. Change `VITE_API_BASE_URL` in `.env` if needed.

## Project structure
```text
StudioBooking/
├── Frontend/                 # React client
├── Backend/
│   ├── StudioBooking.API/    # HTTP endpoints and dependency injection
│   ├── StudioBooking.BUS/    # Business logic
│   ├── StudioBooking.DAL/    # EF Core DbContext and repositories
│   └── StudioBooking.DTO/    # Request/response models
└── Database/                 # SQL Server starter schema and seed data
```

## Starter endpoints
- `GET /api/health`
- `GET /api/services`
- `GET /api/services/{id}`
- `POST /api/bookings`

## Important implementation notes
- Booking creation is currently a starter workflow; availability locking, authentication, contract generation, payment gateway integration, and payment webhook verification must be implemented before production use.
- Never mark a booking as paid based only on the browser redirect. Verify the payment provider's signed webhook / transaction status on the server.
- Store a price and service-description snapshot on each booking so later service edits do not change existing bookings.
