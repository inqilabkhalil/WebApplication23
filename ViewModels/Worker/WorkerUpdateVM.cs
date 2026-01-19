namespace WebApplication23.ViewModels.Worker;

public class WorkerUpdateVM
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public IFormFile Image { get; set; }
  
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public int CategoryId { get; set; }
}