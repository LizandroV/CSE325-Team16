# 🍽 La Casa Peruana — Blazor Restaurant App

Aplicación web de gestión de menú para restaurante peruano, desarrollada con **Blazor Server** + **ASP.NET Core 8** + **SQLite**. Funciona completamente local, sin costo alguno.

---

## 🚀 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8) (gratuito)
- Git

---

## ⚡ Instalación y ejecución

```bash
# 1. Clonar el repositorio
git clone https://github.com/TU_USUARIO/restaurante-app.git
cd restaurante-app

# 2. Entrar al proyecto
cd RestauranteApp

# 3. Restaurar paquetes y ejecutar
dotnet run
```

4. Abrir en el navegador: **http://localhost:5000**

> La base de datos SQLite se crea automáticamente con datos de prueba al primer arranque.

---

## 🔐 Credenciales de acceso

| Usuario | Contraseña |
|---------|------------|
| `admin` | `admin123` |

---

## 🗂 Estructura del proyecto

```
RestauranteApp/
├── RestauranteApp.sln
└── RestauranteApp/
    ├── Components/
    │   ├── Layout/
    │   │   └── MainLayout.razor       ← Header + Footer + Nav
    │   ├── Pages/
    │   │   ├── Home.razor             ← Menú público
    │   │   ├── Login.razor            ← Inicio de sesión
    │   │   └── Admin.razor            ← Panel de administración
    │   ├── App.razor
    │   └── Routes.razor
    ├── Data/
    │   ├── RestauranteDbContext.cs     ← EF Core / SQLite
    │   └── DbSeeder.cs                ← Datos de prueba iniciales
    ├── Models/
    │   ├── MenuItem.cs
    │   └── Usuario.cs
    ├── Services/
    │   ├── MenuService.cs             ← CRUD del menú
    │   └── AuthService.cs             ← Autenticación
    ├── wwwroot/
    │   └── css/app.css
    └── Program.cs
```

---

## 📋 Categorías del menú

| Categoría | Descripción |
|-----------|-------------|
| **MENU** | Entradas y aperitivos |
| **NUESTROS_PLATOS** | Platos principales |
| **ESPECIALES** | Platos especiales de la casa |
| **REFRESCOS** | Bebidas y jugos |

---

## 📱 Features

- ✅ Menú público responsivo (mobile + desktop)
- ✅ Filtro por categorías
- ✅ Marcar platos como agotados (tachado visual)
- ✅ Panel de administración con login
- ✅ CRUD completo de platos (crear, editar, eliminar)
- ✅ Vista previa de imagen al cargar URL
- ✅ Base de datos SQLite local (sin configuración extra)
- ✅ Datos de prueba precargados

---

## 🗺 Sprints del Proyecto

| Sprint | Objetivo | Estado |
|--------|----------|--------|
| **Sprint 1** | Estructura base + Menú público | ✅ Completado |
| **Sprint 2** | Autenticación + Panel Admin | ✅ Completado |
| **Sprint 3** | CRUD completo + Toggle disponibilidad | ✅ Completado |
| **Sprint 4** | Mejoras UX + Búsqueda + Filtros avanzados | 🔜 Pendiente |
| **Sprint 5** | Gestión de usuarios + Roles | 🔜 Pendiente |
| **Sprint 6** | Deploy + CI/CD + Pruebas | 🔜 Pendiente |

---

## 👥 Equipo

Proyecto académico — Curso de Desarrollo .NET

---

## 📜 Licencia

Uso académico. Sin restricciones comerciales.
