namespace RestauranteApp.Models;

public class Usuario
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public bool EsAdmin { get; set; } = true;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
