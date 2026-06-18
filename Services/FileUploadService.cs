namespace RestauranteApp.Services;

public class FileUploadService
{
    private readonly IWebHostEnvironment _env;
    private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
    private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5 MB

    public FileUploadService(IWebHostEnvironment env)
    {
        _env = env;
    }

    /// <summary>
    /// Saves an uploaded image stream to wwwroot/uploads and returns the public relative URL.
    /// </summary>
    public async Task<(bool Success, string UrlOrError)> SaveImageAsync(Stream content, string originalFileName, long size)
    {
        var ext = Path.GetExtension(originalFileName).ToLowerInvariant();

        if (!AllowedExtensions.Contains(ext))
            return (false, "Formato no permitido. Usa JPG, PNG, GIF o WEBP.");

        if (size > MaxFileSizeBytes)
            return (false, "La imagen supera el límite de 5 MB.");

        var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid():N}{ext}";
        var fullPath = Path.Combine(uploadsFolder, fileName);

        using var fileStream = new FileStream(fullPath, FileMode.Create);
        await content.CopyToAsync(fileStream);

        return (true, $"/uploads/{fileName}");
    }

    /// <summary>
    /// Deletes a previously uploaded local image (if the URL points to /uploads/...).
    /// Safe no-op for external URLs or missing files.
    /// </summary>
    public void DeleteLocalImageIfExists(string? imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl)) return;
        if (!imageUrl.StartsWith("/uploads/")) return;

        var fileName = Path.GetFileName(imageUrl);
        var fullPath = Path.Combine(_env.WebRootPath, "uploads", fileName);

        if (File.Exists(fullPath))
        {
            try { File.Delete(fullPath); }
            catch { /* ignore deletion errors */ }
        }
    }
}
