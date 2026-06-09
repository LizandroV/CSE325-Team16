using Microsoft.EntityFrameworkCore;
using RestauranteApp.Data;
using RestauranteApp.Models;

namespace RestauranteApp.Services;

public class AuthService
{
    private readonly RestauranteDbContext _context;
    private Usuario? _usuarioActual;

    public AuthService(RestauranteDbContext context)
    {
        _context = context;
    }

    public bool EstaAutenticado => _usuarioActual != null;
    public Usuario? UsuarioActual => _usuarioActual;

    public event Action? OnAuthStateChanged;

    public async Task<bool> LoginAsync(string username, string password)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.NombreUsuario == username);

        if (usuario == null) return false;

        if (!BCrypt.Net.BCrypt.Verify(password, usuario.PasswordHash)) return false;

        _usuarioActual = usuario;
        OnAuthStateChanged?.Invoke();
        return true;
    }

    public void Logout()
    {
        _usuarioActual = null;
        OnAuthStateChanged?.Invoke();
    }
}
