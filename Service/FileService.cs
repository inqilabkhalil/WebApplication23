using WebApplication23.Service.Interface;

namespace WebApplication23.Service;

public class FileService :IFileService
{
    IWebHostEnvironment _env;
    public FileService(IWebHostEnvironment env)
    {
        _env = env;
        
    }
    public string GenerateUniqueFileName(string fileName)
    {
        return Guid.NewGuid().ToString() + '_' + fileName;
    }

    public string GeneratePath(string folder ,string fileName )
    {
        return Path.Combine(_env.WebRootPath, folder, fileName);
    }

    public void Delete(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public async  Task UploadAsync(IFormFile file, string path)
    {
        using var stream = new FileStream(path,FileMode.Create);
        await file.CopyToAsync(stream);

    }
}