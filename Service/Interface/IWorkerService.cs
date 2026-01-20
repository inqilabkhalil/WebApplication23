using WebApplication23.ViewModels;
using WebApplication23.ViewModels.Category;
using WebApplication23.ViewModels.Worker;

namespace WebApplication23.Service.Interface
{
    public interface IWorkerService
    {
        Task<IEnumerable<WorkerUIVM>> GetAllAsync();
        Task<IEnumerable<WorkerVM>> GetAllAdminAsync();
        Task CreateAsync(WorkerCreateVM model);
        Task UpdateAsync(int id,WorkerUpdateVM model);
        Task DeleteAsync(int id);
        Task<WorkerDetailVM> GetByIdAsync(int id);
        

    }
}
