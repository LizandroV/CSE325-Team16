using Microsoft.EntityFrameworkCore;
using RestauranteApp.Data;
using RestauranteApp.Models;

namespace RestauranteApp.Services;

public class MenuService
{
    private readonly RestauranteDbContext _context;

    public MenuService(RestauranteDbContext context)
    {
        _context = context;
    }

    public async Task<List<MenuItem>> GetAllAsync()
        => await _context.MenuItems.OrderBy(m => m.Orden).ToListAsync();

    public async Task<List<MenuItem>> GetByCategoriaAsync(string categoria)
        => await _context.MenuItems
            .Where(m => m.Categoria == categoria)
            .OrderBy(m => m.Orden)
            .ToListAsync();

    public async Task<MenuItem?> GetByIdAsync(int id)
        => await _context.MenuItems.FindAsync(id);

    public async Task<MenuItem> CreateAsync(MenuItem item)
    {
        _context.MenuItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<MenuItem?> UpdateAsync(MenuItem item)
    {
        var existing = await _context.MenuItems.FindAsync(item.Id);
        if (existing == null) return null;

        existing.Nombre = item.Nombre;
        existing.Descripcion = item.Descripcion;
        existing.Precio = item.Precio;
        existing.Categoria = item.Categoria;
        existing.ImagenUrl = item.ImagenUrl;
        existing.Disponible = item.Disponible;
        existing.Orden = item.Orden;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> ToggleDisponibilidadAsync(int id)
    {
        var item = await _context.MenuItems.FindAsync(id);
        if (item == null) return false;

        item.Disponible = !item.Disponible;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.MenuItems.FindAsync(id);
        if (item == null) return false;

        _context.MenuItems.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }

    public static List<string> GetCategorias()
        => new() { "MENU", "NUESTROS_PLATOS", "ESPECIALES", "REFRESCOS" };

    public static string GetCategoriaLabel(string categoria) => categoria switch
    {
        "MENU" => "Menú",
        "NUESTROS_PLATOS" => "Nuestros Platos",
        "ESPECIALES" => "Especiales",
        "REFRESCOS" => "Refrescos",
        _ => categoria
    };
}
