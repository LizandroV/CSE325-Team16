using Microsoft.EntityFrameworkCore;
using RestauranteApp.Components;
using RestauranteApp.Data;
using RestauranteApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(options =>
    {
        options.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10 MB, allows image uploads
    });

builder.Services.AddDbContext<RestauranteDbContext>(options =>
    options.UseSqlite("Data Source=restaurante.db"));

builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<FileUploadService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RestauranteDbContext>();
    await DbSeeder.SeedAsync(context);
}

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
