namespace Wardrobe.Service
{
    public class ImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public ImageService(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public async Task<string> SaveImageAsync(Stream imageStream, string fileName)
        {
            var uploadFolder = Path.Combine(_environment.WebRootPath, _configuration["ImageFolder"]);
            Console.WriteLine(uploadFolder);
            var filePath = Path.Combine(uploadFolder, fileName);

            using (var filesStream = new FileStream(filePath, FileMode.Create))
            {
                await imageStream.CopyToAsync(filesStream);
            }
            Console.WriteLine(filePath);
            return fileName;
        }
    }
}
