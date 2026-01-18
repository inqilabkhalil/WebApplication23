using WebApplication23.ViewModels;

namespace WebApplication23.Service.Interface
{
    public interface IWorkerService
    {
        Task<IEnumerable<WorkerUIVM>> GetAllAsync();
    }
}
