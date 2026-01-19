namespace WebApplication23.Service.Interface;

public interface IFileService
{
   string GenerateUniqueFileName(string fileName);
   string GeneratePath( string folder,string fileName);
   void Delete(string path);
   Task UploadAsync(IFormFile file, string path);

}