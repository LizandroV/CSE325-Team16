# La Casa Peruana — Restaurant Menu App

Blazor Server · ASP.NET Core 8 · SQLite

---

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)

## Run locally

```bash
git clone https://github.com/LizandroV/CSE325-Team16.git
cd CSE325-Team16
dotnet run
```

Open `http://localhost:5000` in your browser.

## Admin login

| Username | Password   |
| -------- | ---------- |
| `admin`  | `admin123` |

---

## Project structure

```
CSE325-Team16/
├── Components/
│   ├── Layout/MainLayout.razor
│   └── Pages/
│       ├── Home.razor
│       ├── Login.razor
│       └── Admin.razor
├── Data/
│   ├── RestauranteDbContext.cs
│   └── DbSeeder.cs
├── Models/
│   ├── MenuItem.cs
│   └── Usuario.cs
├── Services/
│   ├── MenuService.cs
│   └── AuthService.cs
├── wwwroot/css/app.css
└── Program.cs
```

---

## Sprints

| Sprint | Goal                            | Status     |
| ------ | ------------------------------- | ---------- |
| 1      | Project setup + Public menu     | ✅ Done    |
| 2      | Authentication + Admin panel    | ✅ Done    |
| 3      | Full CRUD + Availability toggle | ✅ Done    |
| 4      | UX improvements + Search        | 🔜 Pending |
| 5      | User management + Roles         | 🔜 Pending |
| 6      | Deploy + Testing                | 🔜 Pending |
