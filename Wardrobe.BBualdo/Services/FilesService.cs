using Microsoft.AspNetCore.Components.Forms;

namespace Wardrobe.BBualdo.Services;

public class FilesService(IConfiguration config) : IFilesService
{
    private readonly IConfiguration _config = config;
    private readonly long _maxFileSizeInBytes = 1024 * 1024 * 3;
    public List<string> Errors = new();
    
    public async Task<string> CaptureFile(IBrowserFile? file)
    {
        if (file is null) return "";

        try
        {
            string newFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(file.Name));
            string path = Path.Combine(_config.GetValue<string>("FileStorage")!, _config.GetValue<string>("User")!, newFileName);
            string relativePath = Path.Combine(_config.GetValue<string>("User")!, newFileName);

            Directory.CreateDirectory(Path.Combine(_config.GetValue<string>("FileStorage")!, _config.GetValue<string>("User")!));

            await using FileStream fs = new(path, FileMode.Create);
            await file.OpenReadStream(_maxFileSizeInBytes).CopyToAsync(fs);
            return relativePath;
        }
        catch (Exception ex)
        {
            Errors.Add($"Error: {ex.Message}");
            throw;
        }
    }
}