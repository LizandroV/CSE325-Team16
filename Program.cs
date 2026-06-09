using Microsoft.EntityFrameworkCore;
using RestauranteApp.Components;
using RestauranteApp.Data;
using RestauranteApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// SQLite Database
builder.Services.AddDbContext<RestauranteDbContext>(options =>
    options.UseSqlite("Data Source=restaurante.db"));

// App Services
builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RestauranteDbContext>();
    await DbSeeder.SeedAsync(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
