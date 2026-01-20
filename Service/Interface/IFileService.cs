namespace WebApplication23.Service.Interface;

public interface IFileService
{
    void Delete(string path);
    string GenerateUniqueFileName(string fileName);
    string GeneratePath(string folder, string fileName);
    Task UploadAsync(IFormFile file, string path);

}