namespace WebApplication23.ViewModels.Worker;

public class WorkerCreateVM
{
    public string FullName { get; set; }

    public IFormFile Image { get; set; }
  
    public string Description { get; set; }
   
    public int CategoryId { get; set; }
    
}