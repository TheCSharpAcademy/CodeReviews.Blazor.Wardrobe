using Microsoft.AspNetCore.Components.Forms;

namespace Wardrobe.BBualdo.Services;

public interface IFilesService
{
    Task<string> CaptureFile(IBrowserFile file);
}